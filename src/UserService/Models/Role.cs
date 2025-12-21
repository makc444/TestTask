using System.ComponentModel.DataAnnotations;
using UserService.Domain;

namespace UserService.Models;

public class Role
{
    public int Id { get; set; }
    
    public RoleType Type { get; set; } = RoleType.User;

    public List<User> Users { get; } = [];
}