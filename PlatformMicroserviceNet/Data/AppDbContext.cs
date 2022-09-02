using Microsoft.EntityFrameworkCore;
using PlatformMicroserviceNet.Domain;

namespace PlatformMicroserviceNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
    }
}
