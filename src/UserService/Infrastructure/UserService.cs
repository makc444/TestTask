using Microsoft.EntityFrameworkCore;
using UserService.Application;
using UserService.Domain;
using UserService.Models;

namespace UserService.Infrastructure;

public class UserService : IUserService
{
    private readonly ApplicationContext _context;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public UserService(ApplicationContext context, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<User> SaveUserAsync(string? login, string? password, string? email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(login);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        var pass = _passwordHasher.Generate(password);

        var role = _context.Roles.SingleOrDefault(r => r.Type == RoleType.User)
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

        var userDb = await _context.Users
            .Where(u => u.Login == login)
            .Include(u => u.Roles)
            .SingleOrDefaultAsync();

        if (userDb == null)
        {
            throw new Exception("User not found");
        }

        var endCrypt = _passwordHasher.Verify(password, userDb.Password);

        if (endCrypt is false)
        {
            throw new Exception("Invalid login or password");
        }
        
        var token = _jwtProvider.GenerateToken();
        
        return userDb;
    }
}