namespace BooksService.DTO;

public class CreateBookResponse
{
    public required long Id { get; set; }
    public required string Title { get; set; } = "";
    public required string AuthorName { get; set; } = "";
    public required long UserId { get; set; }
}