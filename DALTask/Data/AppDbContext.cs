using DALTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DALTask.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
    
    }
}
