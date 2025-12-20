using System.ComponentModel.DataAnnotations;

namespace UserService.Models;

public class User
{
    [Key]
    public long Id { get; set; }
    
    public string Login { get; set; } 
    
    public string Password { get; set; }
    
    public string Email { get; set; }
}