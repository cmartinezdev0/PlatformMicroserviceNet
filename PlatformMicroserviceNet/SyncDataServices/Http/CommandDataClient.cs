using PlatformMicroserviceNet.Dtos;
using System.Diagnostics;
using System.Text;

namespace PlatformMicroserviceNet.SyncDataServices.Http
{
    public class CommandDataClient : ICommandDataClient
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public CommandDataClient(IConfiguration config, HttpClient client)
        {
            _config = config;
            _client = client;
        }

        public async Task SendPlatformToCommand(PlatformReadDto dto)
        {
            var body = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(dto),
                    Encoding.UTF8,
                    "application/json");
            var response = await _client.PostAsync($"{_config["CommandService"]}", body);
            if (!response.IsSuccessStatusCode)
                Debug.WriteLine("--> ERROR SENDING PLATFORM TO COMMAND SERVICE APP");
        }
    }
}
