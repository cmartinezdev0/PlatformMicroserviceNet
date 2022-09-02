using Microsoft.EntityFrameworkCore;
using PlatformMicroserviceNet.Models;

namespace PlatformMicroserviceNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<PlatformModel> Platforms { get; set; }
    }
}
