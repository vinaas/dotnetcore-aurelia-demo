using Microsoft.EntityFrameworkCore;

namespace my_app.Infrastructure
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
    }
}