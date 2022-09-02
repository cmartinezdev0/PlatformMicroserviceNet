using PlatformMicroserviceNet.Models;

namespace PlatformMicroserviceNet.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<PlatformModel> GetAllPlatforms();

        PlatformModel GetPlatformById(int id);

        void CreatePlatform(PlatformModel platform);
    }
}
