using PlatformMicroserviceNet.Models;

namespace PlatformMicroserviceNet.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _db;

        public PlatformRepo(AppDbContext db)
        {
            _db = db;
        }

        public void CreatePlatform(PlatformModel platform)
        {
            if (platform == null) 
                throw new ArgumentNullException(nameof(platform));

            _db.Platforms.Add(platform);
        }

        public IEnumerable<PlatformModel> GetAllPlatforms()
        {
            return _db.Platforms.ToList();
        }

        public PlatformModel GetPlatformById(int id)
        {
            return _db.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return _db.SaveChanges() >= 0;
        }
    }
}
