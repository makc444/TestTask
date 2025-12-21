using UserService.Domain;
using UserService.Models;

namespace UserService.DTO;

public class UserResponse
{
    public string Login { get; set; } = String.Empty;
    
    public List<RoleType> Role { get; set; }
}