using Microsoft.EntityFrameworkCore;
using WebAPIdbcon.Models;

namespace WebAPIdbcon.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Student> student { get; set; }
    }
}
