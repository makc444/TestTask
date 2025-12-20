namespace UserService.DTO;

public class UserRequestLogin
{
    public string? Login { get; set; } = String.Empty;
    
    public string? Password { get; set; } = String.Empty;
}