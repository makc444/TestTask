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
        
        var pass = BCrypt.Net.BCrypt.HashPassword(password);
        
        await _context.Users.AddAsync(new User(){Email = email, Password = pass, Login = login});
        
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserAsync(string? login, string? password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(login);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        User? userDb = await _context.Users.Where(u => u.Login == login).SingleOrDefaultAsync();
        
        var isUserNotNull = BCrypt.Net.BCrypt.Verify(password, userDb.Password);

        if (isUserNotNull != true)
        {
            throw new Exception("Invalid login or password");
        }
        
        return userDb;
    }
}