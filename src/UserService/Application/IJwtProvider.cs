using UserService.Models;

namespace UserService.Application;

public interface IJwtProvider
{
    string GenerateToken(User user);
}