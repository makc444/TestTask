using BooksService.Domain;
using BooksService.DTO;

namespace BooksService.Handlers;

public class CreateBookHandler
{
    private readonly BooksContext _context;

    public CreateBookHandler(BooksContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateBookResponse> Create(CreateBookRequest request)
    {
        var bookEntity = new Book()
        {
            Title = request.Title,
            AuthorName = request.AuthorName,
            UserId = request.UserId
        };

        await _context.Books.AddAsync(bookEntity);

        await _context.SaveChangesAsync();

        var response = new CreateBookResponse()
        {
            Id = bookEntity.Id,
            AuthorName = request.AuthorName,
            Title = request.Title,
            UserId = request.UserId
        };

        return response;
    }
}