using Microsoft.EntityFrameworkCore;
using UserService.Application;
using UserService.Models;

namespace UserService.Infrastructure;

public class UserService : IUserService
{
    private readonly ApplicationContext _context;

    public UserService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task SaveUserAsync(string? login, string? password, string? email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(login);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        
        await _context.Users.AddAsync(new User(){Email = email, Password = password, Login = login});
        
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserAsync(string? login, string? password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(login);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        var user = await _context.Users
            .SingleOrDefaultAsync(u => u.Login == login && u.Password == password);
        
        return user;
    }
}