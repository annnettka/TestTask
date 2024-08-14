using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Models;

namespace TestTask.Domain.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Announcement> Announcements { get; set; } 
}