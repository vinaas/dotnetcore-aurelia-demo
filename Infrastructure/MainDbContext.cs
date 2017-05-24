using Microsoft.EntityFrameworkCore;

namespace dotnetcore_aurelia_demo.Infrastructure
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
    }
}