using Microsoft.EntityFrameworkCore;

namespace UserManagementSystem.Src.Infrastructure.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
