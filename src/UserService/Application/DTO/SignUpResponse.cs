using Microsoft.Extensions.Options;
using UserService.Domain;
using UserService.Models;

namespace UserService.DTO;

public class SignUpResponse
{
    public string Login { get; set; } = String.Empty;
    
    public List<RoleType> Role { get; set; }
    
}