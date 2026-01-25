namespace UserService.Application;

using UserService.DTO;
using UserService.Models;

public interface IJwtProvider
{
    string GenerateToken(User user);
}