using BTApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BTApp.DataAccess.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<UserPassword> UserPasswords { get; set; }
    }
}
