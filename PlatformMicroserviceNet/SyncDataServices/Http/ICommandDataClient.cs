using PlatformMicroserviceNet.Dtos;

namespace PlatformMicroserviceNet.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto dto);
    }
}
