using PlatformMicroserviceNet.Models;

namespace PlatformMicroserviceNet.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }

        private static void SeedData(AppDbContext db)
        {
            if (db == null)
                throw new ArgumentNullException(nameof(db));

            if (!db.Platforms.Any())
            {
                db.Platforms.AddRange(GetMockData());
                db.SaveChanges();
            }
        }

        private static List<Platform> GetMockData()
        {
            return new List<Platform>()
            {
                new Platform()
                {
                    Name = "Dot Net",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "SQL Server Express",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "Kubernetes",
                    Publisher = "Cloud Native Computing Foundation",
                    Cost = "Free"
                }
            };
        }
    }
}
