using ApiGateway.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.Application;

namespace ApiGateway.Controllers;

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
    
    [HttpPost]
    public async Task<ActionResult<UserResponse>> PostSignUp(UserRequest request)
    {
        await _userService.SaveUserAsync(request.Name, request.Password, request.Email);

        return Ok("Успех");
    }

    [HttpPost]

    public async Task<ActionResult<UserResponse>> PostSignIn(UserRequest request)
    {
        return Ok();
    }
}