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
    public async Task<ActionResult<SignUpResponse>> PostSignUp(SignUpRequest signUpRequest)
    {
        var user = await _userService.SaveUserAsync(signUpRequest.Login, signUpRequest.Password, signUpRequest.Email);
        
        var response = new SignUpResponse()
        {
            Login = user.Login,
            
            Role = user.Roles.Select(r=>r.Type).ToList(),
        };

        return Ok(response);
    }

    [HttpPost("SignIn")]

    public async Task<ActionResult<SignInResponse>> PostSignIn(SignInRequest signInRequest)
    {
        var user = await _userService.GetUserAsync(signInRequest.Login, signInRequest.Password);
        
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

        var response = new SignInResponse()
        {
            Login = user.Login,
        };
        
        return Results.Ok(token);
    }

    [HttpGet("Test")]
    [Authorize]
    public async Task<ActionResult<SignUpResponse>> GetTestCookie()
    {
        
        
        return Ok("Okey, Boss");
    }
}