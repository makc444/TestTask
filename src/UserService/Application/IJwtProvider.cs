namespace UserService.Application;

using Models;

public interface IJwtProvider
{
    string GenerateToken(User user);
}