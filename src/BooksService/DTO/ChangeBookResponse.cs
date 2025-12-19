namespace BooksService.DTO;

public class ChangeBookResponse
{
    public long Id { get; set; }
    public string Title { get; set; } = "";
    public string AuthorName { get; set; } = "";
}