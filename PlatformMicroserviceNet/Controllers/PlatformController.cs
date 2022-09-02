using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformMicroserviceNet.Data;
using PlatformMicroserviceNet.Domain;
using PlatformMicroserviceNet.Dtos;

namespace PlatformMicroserviceNet.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepo platformRepo, 
            IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
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
        public IActionResult CreatePlatform(PlatformCreateDto dto)
        {
            if (dto == null) return BadRequest();
            var platform = _mapper.Map<Platform>(dto);
            _platformRepo.CreatePlatform(platform);
            _platformRepo.SaveChanges();
            var resultDto = _mapper.Map<PlatformReadDto>(platform);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = resultDto.Id }, resultDto);
        }
    }
}
