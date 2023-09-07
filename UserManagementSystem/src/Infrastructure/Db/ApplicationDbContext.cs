using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Src.Core.Entities;

namespace UserManagementSystem.Src.Infrastructure.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
