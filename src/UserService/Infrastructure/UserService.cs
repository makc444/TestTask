using Microsoft.EntityFrameworkCore;
using UserService.Application;
using UserService.Domain;
using UserService.Models;

namespace UserService.Infrastructure;

public class UserService : IUserService
{
    private readonly ApplicationContext _context;

    public UserService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<User> SaveUserAsync(string? login, string? password, string? email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(login);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        
        var pass = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        
        var role = _context.Roles.SingleOrDefault(r=>r.Type == RoleType.User) 
                   ?? throw new InvalidOperationException("Role not found");
        
        var user = new User()
            { Email = email, Password = pass, Login = login, Roles = { role } };
        
        await _context.Users.AddAsync(user);
        
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetUserAsync(string? login, string? password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(login);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        var userDb = await _context.Users.Where(u => u.Login == login).SingleOrDefaultAsync();

        if (userDb == null)
        {
            throw new Exception("User not found");
        }

        if (BCrypt.Net.BCrypt.Verify(password, userDb.Password) is false)
        {
            throw new Exception("Invalid login or password");
        }
        
        return userDb;
    }

    /*public async Task<User?> GetUserAuthAsync(string? login,  string? password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(login);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);
        
        var userDb = await _context.Users.Where(u => u.Login == login).SingleOrDefaultAsync();

        if (userDb == null)
        {
            throw new Exception("User not found");
        }
                
        return userDb;
    }*/
    
}