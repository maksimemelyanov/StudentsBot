using Microsoft.EntityFrameworkCore;
using StudentsBot.Students.Domain.Groups;
using StudentsBot.Students.Domain.Students;

namespace StudentsBot.Students.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
}