using Microsoft.EntityFrameworkCore;

namespace UserService.Models;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    private readonly string _connectionString;
    
    public ApplicationContext( IConfiguration configuration) 
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") 
                           ?? throw new InvalidOperationException();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

}