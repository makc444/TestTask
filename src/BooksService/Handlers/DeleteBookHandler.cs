using Microsoft.EntityFrameworkCore;

namespace BooksService.Handlers;

public class DeleteBookHandler
{
    private readonly BooksContext _context;

    public DeleteBookHandler(BooksContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task Delete(long id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) throw new KeyNotFoundException(nameof(book));

        await _context.SaveChangesAsync();
    }
}