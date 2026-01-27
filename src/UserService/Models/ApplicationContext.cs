using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UserService.Models;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    private readonly string _connectionString;

    public ApplicationContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("Connection string is not found");
    }

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().Property(x => x.Type).HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
}