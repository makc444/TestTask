using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        var user = await _userService.SaveUserAsync(request.Login, request.Password, request.Email);
        
        var response = new UserResponse()
        {
            Login = user.Login,
            
            Role = user.Roles.Select(r=>r.Type).ToList(),
        };

        return Ok(response);
    }

    [HttpPost("SignIn")]

    public async Task<ActionResult<UserResponseLogin>> PostSignIn(UserRequestLogin request)
    {
        var user = await _userService.GetUserAsync(request.Login, request.Password);
        
        if (user == null)
        {
            return NotFound("Not found user");
        }

        var cliams = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, user.Roles.First().Type.ToString())
        };
          
        var identity = new ClaimsIdentity(cliams, CookieAuthenticationDefaults.AuthenticationScheme);
        
        var principal = new ClaimsPrincipal(identity);
        
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,
        new AuthenticationProperties { IsPersistent = true });

        var response = new UserResponseLogin()
        {
            Login = user.Login,
        };
        
        return Ok(response);
    }

    [HttpGet("Test")]
    [Authorize]
    public async Task<ActionResult<UserResponse>> GetTestCookie()
    {
        
        
        return Ok("Okey, Boss");
    }
    
}