namespace UserService.DTO;

public class UserSignUpRequest
{
    public string? Login { get; set; } = String.Empty;
    
    public string? Password { get; set; } =  String.Empty;
    
    public string? Email { get; set; }  =  String.Empty;
}