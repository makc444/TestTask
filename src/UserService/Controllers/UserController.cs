using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.Application;
using UserService.DTO;

namespace UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    [HttpPost("SignUp")]
    public async Task<ActionResult<UserResponse>> PostSignUp(UserRequest request)
    {
        await _userService.SaveUserAsync(request.Login, request.Password, request.Email);

        return Ok("Успех");
    }

    [HttpPost("SignIn")]

    public async Task<ActionResult<UserResponseLogin>> PostSignIn(UserRequestLogin request)
    {
        var user = await _userService.GetUserAsync(request.Login, request.Password);

        if (user == null)
        {
            return NotFound("Not found user");
        }

        var response = new UserResponseLogin()
        {
            Login = user.Login,
        };
        
        return response;
    }
}