using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Kinopoisk.Services.User;

public class UserService : IUserService {
    private readonly DataContext context;
    private readonly IMapper mapper;
    private readonly IConfiguration configuration;

    public UserService(DataContext context, IConfiguration configuration, IMapper mapper) {
        this.mapper = mapper;   
        this.context = context;
        this.configuration = configuration;
    }

    public async Task<AuthenticateResponse?> Authenticate(AuthenticateUserDTO model) {
        var user = await context.Users.SingleOrDefaultAsync(
            user => user.Username == model.Username && user.Password == model.Password
        );
        if (user == null) 
            return null;

        var token = await GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }
    private async Task<string> GenerateJwtToken(UserModel user) {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() => {
            string? jwtSecret = configuration["ApplicationSettings:JWT_Secret"];
            if (jwtSecret == null) 
                throw new ArgumentException("Can't find jwt secret string");

            var key = Encoding.ASCII.GetBytes(jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(
                    [new Claim("username", user.Username)]
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        });
        return tokenHandler.WriteToken(token);
    }

    public async Task<GetUserDTO> CreateUser(CreateUserDTO createUserDTO) {
        var user = mapper.Map<UserModel>(createUserDTO);
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return mapper.Map<GetUserDTO>(user); 
    }

    public Task<Hashtable> DeleteUser(string name) {
        throw new NotImplementedException();
    }

    public async Task<GetUserDTO> GetUser(string username) {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Username == username);
        return mapper.Map<GetUserDTO>(user);
    }

    public async Task<List<GetUserDTO>> GetUsers() {
        var users = await context.Users.ToListAsync();
        return users.Select(mapper.Map<GetUserDTO>).ToList();    
    }

    public Task<GetUserDTO> UpdateUser(UpdateUserDTO updateUserDTO) {
        throw new NotImplementedException();
    }
}