using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
namespace Kinopoisk.Helpers;

public class JwtMiddleware {
    private readonly RequestDelegate next;
    private readonly IConfiguration configuration;

    public JwtMiddleware(RequestDelegate next, IConfiguration configuration) {
        this.next = next;
        this.configuration = configuration;
    }
    public async Task Invoke(HttpContext context, IUserService userService) {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await AttachUserToContext(context, userService, token);

        await next(context);
    }
    private async Task AttachUserToContext(HttpContext context, IUserService userService, string token) {
        try {
            var tokenHandler = new JwtSecurityTokenHandler();
            string? jwtSecret = configuration["ApplicationSettings:JWT_Secret"];
            if (jwtSecret == null) 
                throw new ArgumentException("Can't find jwt secret string");

            var key = Encoding.ASCII.GetBytes(jwtSecret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            string username = jwtToken.Claims.First(x => x.Type == "username").Value;

            context.Items["User"] = await userService.GetUser(username);
        }
        catch {
            //Do nothing if JWT validation fails
            // user is not attached to context so the request won't have access to secure routes
        }
    }
}