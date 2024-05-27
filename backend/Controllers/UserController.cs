using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kinopoisk.Controllers;

[ApiController] 
[Route("users")]
public class UserController : ControllerBase {
    private readonly IUserService userService;

    public UserController(IUserService userService) {
        this.userService = userService;
    } 

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<GetUserDTO>>> Index() => 
        Ok(await userService.GetUsers());

    [Authorize]
    [HttpGet("{name}")]
    public async Task<ActionResult<GetUserDTO>> Get(string name) => 
        Ok(await userService.GetUser(name));

    [HttpPost("create")]
    public async Task<ActionResult<GetUserDTO>> Create(CreateUserDTO createUserDTO) => 
        Ok(await userService.CreateUser(createUserDTO));

    [HttpPost("authorize")]
    public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateUserDTO authenticateUserDTO) => 
        Ok(await userService.Authenticate(authenticateUserDTO));
}