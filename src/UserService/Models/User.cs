using System.ComponentModel.DataAnnotations;

namespace UserService.Models;

public class User
{
    [Key]
    public long Id { get; set; }
    
    [MaxLength(100)]
    public required string Login { get; set; } 
    
    [MaxLength(100)]
    public required string Password { get; set; }
    
    [MaxLength(100)]
    public required string Email { get; set; }

    public List<Role> Roles { get; } = [];
}