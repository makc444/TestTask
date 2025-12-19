namespace UserService.Application;

public interface IUserService
{
    Task SaveUserAsync(string? name, string? password, string? email);
}