using UserService.Models;

namespace UserService.Application;

public interface IUserService
{
    Task SaveUserAsync(string? login, string? password, string? email);
    
    Task<User?> GetUserAsync(string? login, string? password);
}