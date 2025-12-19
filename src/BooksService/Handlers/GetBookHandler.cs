using BooksService.Domain;
using BooksService.DTO;

namespace BooksService.Handlers;

public class GetBookHandler
{
    private readonly BooksContext _context;

    public GetBookHandler(BooksContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetBookResponse> Find(long id)
    {
        var result = await _context.Books.FindAsync(id);

        if (result == null) throw new KeyNotFoundException(nameof(result));

        var dto = new GetBookResponse()
        {
            AuthorName = result.AuthorName,
            Title = result.Title,
            Id = result.Id
        };

        return dto;
    }
}