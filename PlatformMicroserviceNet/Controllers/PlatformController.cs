using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformMicroserviceNet.Data;
using PlatformMicroserviceNet.Models;
using PlatformMicroserviceNet.Dtos;
using PlatformMicroserviceNet.SyncDataServices.Http;
using System.Diagnostics;

namespace PlatformMicroserviceNet.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformController(IPlatformRepo platformRepo, 
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public IActionResult GetPlatforms()
        {
            var allPlatforms = _platformRepo.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(allPlatforms));
        }

        [HttpGet]
        [Route("{id}", Name = "GetPlatformById")]
        public IActionResult GetPlatformById(int id)
        {
            var platform = _platformRepo.GetPlatformById(id);
            if (platform == null) return NotFound();
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform(PlatformCreateDto dto)
        {
            if (dto == null) return BadRequest();
            var platform = _mapper.Map<Platform>(dto);
            _platformRepo.CreatePlatform(platform);
            _platformRepo.SaveChanges();
            var resultDto = _mapper.Map<PlatformReadDto>(platform);

            try
            {
                await _commandDataClient.SendPlatformToCommand(resultDto);
            }
            catch (Exception e)
            {
                Debug.WriteLine(" --> ERROR SENDING NEW PLATFORM TO COMMAND", e.Message);
            }
            
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = resultDto.Id }, resultDto);
        }
    }
}
