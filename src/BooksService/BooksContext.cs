using BooksService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BooksService;

public class BooksContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Book> Books { get; set; }

    public BooksContext(DbContextOptions<BooksContext> options, IConfiguration configuration) : base(options)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ??
                            throw new InvalidOperationException("Connection string is null");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}