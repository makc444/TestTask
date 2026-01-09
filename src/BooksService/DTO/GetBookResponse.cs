namespace BooksService.DTO;

public class GetBookResponse
{
    public required long Id { get; set; }
    public required string Title { get; set; }
    public required string AuthorName { get; set; }
}