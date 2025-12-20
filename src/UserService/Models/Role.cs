using System.ComponentModel.DataAnnotations;

namespace UserService.Models;

public class Role
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public required string RoleName { get; set; } 

    public List<User> Users { get; } = [];
}