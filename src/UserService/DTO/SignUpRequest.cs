namespace UserService.DTO;

public record SignUpRequest
{
    public string? Login { get; set; } = String.Empty;
    
    public string? Password { get; set; } =  String.Empty;
    
    public string? Email { get; set; }  =  String.Empty;
}