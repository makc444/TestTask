namespace UserService.DTO;

public record SignInResponse
{
    public string? Login { get; set; }

    public string? Token { get; set; }
}