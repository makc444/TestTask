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

    public async Task SaveUserAsync(string? name, string? password, string? email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        
        await _context.Users.AddAsync(new User(){Email = email, Password = password, Name = name});
        
        await _context.SaveChangesAsync();
    }
}