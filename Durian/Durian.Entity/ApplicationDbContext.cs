using Microsoft.EntityFrameworkCore;

namespace Durian.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Role> Roles { get; set; }
    }
}