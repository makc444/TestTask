namespace BooksService.DTO;

public class CreateBookRequest
{
    public string Title { get; set; } = "";
    public string AuthorName { get; set; } = "";
    public long UserId { get; set; }
}