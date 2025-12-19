using ApiGateway.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> PostSignIn(string name, string password)
    {
        var a = new UserResponse
        {
            Name = name,
            Password = password
        };

        return Ok(a);
    }
}