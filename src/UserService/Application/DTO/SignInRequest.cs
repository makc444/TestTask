namespace UserService.DTO;

public record SignInRequest
{
    public string? Login { get; set; } = String.Empty;

    public string? Password { get; set; } = String.Empty;

    public string? Email { get; set; }
}