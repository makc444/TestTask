using Microsoft.AspNetCore.Identity;
using UserService.Application;

namespace UserService.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    /// <inheritdoc/>
    public string Generate(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    /// <inheritdoc/>
    public bool Verify(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}