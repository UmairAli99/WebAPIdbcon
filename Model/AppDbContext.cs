using Microsoft.EntityFrameworkCore;
using SharedClassLibrary;

namespace WebAPIdbcon.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> student { get; set; }
    }
}