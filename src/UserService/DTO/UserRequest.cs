namespace UserService.DTO;

public class UserRequest
{
    public string? Login { get; set; } = String.Empty;
    
    public string? Password { get; set; } =  String.Empty;
    
    public string? Email { get; set; }  =  String.Empty;
}