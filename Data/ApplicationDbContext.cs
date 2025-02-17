using Microsoft.EntityFrameworkCore;
using IgloobalTestBackendCSharp.Models;

namespace IgloobalTestBackendCSharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}