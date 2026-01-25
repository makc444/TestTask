namespace UserService.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.Application;
using UserService.DTO;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly IJwtProvider _jwtProvider;

    public UserController(ILogger<UserController> logger, IUserService userService, IJwtProvider jwtProvider)
    {
        _logger = logger;
        _userService = userService;
        _jwtProvider = jwtProvider;
    }

    [HttpPost("SignUp")]
    public async Task<ActionResult<SignUpResponse>> PostSignUp(SignUpRequest signUpRequest)
    {
        var user = await _userService.SaveUserAsync(
            signUpRequest.Login, signUpRequest.Password, signUpRequest.Email);

        var response = new SignUpResponse()
        {
            Login = user.Login,

            Role = user.Roles.Select(r => r.Type).ToList(),
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

        var token = _jwtProvider.GenerateToken(user);

        var response = new SignInResponse()
        {
            Login = user.Login,
            Token = token,
        };

        return Ok(response);
    }

    [HttpGet("Test")]
    [Authorize]
    public async Task<ActionResult<SignUpResponse>> GetTestCookie()
    {
        return Ok("Okey, Boss");
    }

    [HttpGet("Test2")]
    [Authorize]
    public async Task<ActionResult<string>> GetTestString()
    {
        var test = _userService.GetTestStringProb();
        return Ok(test);
    }

}