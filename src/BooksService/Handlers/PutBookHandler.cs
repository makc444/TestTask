using BooksService.DTO;
using Microsoft.EntityFrameworkCore;

namespace BooksService.Handlers;

public class PutBookHandler
{
    private readonly BooksContext _context;

    public PutBookHandler(BooksContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<ChangeBookResponse> Change(ChangeBookRequest request)
    {
        var book = await _context.Books.FindAsync(request.Id);
        if (book == null) throw new KeyNotFoundException(nameof(book));

        book.AuthorName = request.AuthorName;
        book.Title = request.Title;

        var entry = _context.Books.Update(book);
        await _context.SaveChangesAsync();

        return new ChangeBookResponse()
        {
            Id = entry.Entity.Id,
            AuthorName = entry.Entity.AuthorName,
            Title = entry.Entity.Title
        };
    }
}