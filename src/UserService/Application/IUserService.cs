using UserService.Models;

namespace UserService.Application;

public interface IUserService
{
    Task<User> SaveUserAsync(string? login, string? password, string? email);
    
    Task<User?> GetUserAsync(string? login, string? password);
    
    
}