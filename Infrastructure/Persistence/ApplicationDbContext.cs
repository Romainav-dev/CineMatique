using Microsoft.EntityFrameworkCore;
using Domain.Entities.Films;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public ApplicationDbContext() : base(new DbContextOptions<ApplicationDbContext>()) { }

    public DbSet<Film> Films { get; set; }
    public DbSet<Genre> Genres { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>().ToTable("Films");
        modelBuilder.Entity<Genre>().ToTable("Genres");
    }
}