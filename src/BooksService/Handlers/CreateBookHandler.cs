using BooksService.Domain;

namespace BooksService.Handlers;

public class CreateBookHandler
{
    private readonly BooksContext _context;

    public CreateBookHandler(BooksContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Create(long id, string authorName, string title, long userId)
    {
        var a = new Book()
        {
            Title = title,
            AuthorName = authorName,
            Id = id,
            UserId = userId
        };

        _context.Books.Add(a);
    }
}