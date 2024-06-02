using System.Collections;

namespace Kinopoisk.Services.User;

public interface IUserService {
    public Task<AuthenticateResponse> Authenticate(AuthenticateUserDTO model);
    public Task<List<GetUserDTO>> GetUsers();
    public Task<GetUserDTO> GetUser(string name);
    public Task<GetUserDTO> CreateUser(CreateUserDTO createUserDTO);
    public Task<GetUserDTO> UpdateUser(UpdateUserDTO updateUserDTO);
    public Task<Hashtable> DeleteUser(string name);

}