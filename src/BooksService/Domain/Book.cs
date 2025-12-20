using System.ComponentModel.DataAnnotations;

namespace BooksService.Domain;

public class Book
{
    [Key] public long Id { get; set; }

    public required long UserId { get; set; }
    public required string Title { get; set; }
    public required string AuthorName { get; set; }
}