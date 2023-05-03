using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataService.Http;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(IPlatformRepo repo, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _repo = repo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            // var listPlatformReadDto = new List<PlatformReadDto>();
            // Console.WriteLine("--> Getting Platforms....");
            // var platformItem = _repo.GetAllPlatforms();
            // foreach(var item in platformItem)
            // {
            //     listPlatformReadDto.Add(new PlatformReadDto
            //     {
            //         Id = item.Id,                                        // gapake auto mapping
            //         Name = item.Name,
            //         Publisher = item.Publisher,
            //         Cost = item.Cost
            //     });
            // }
            // return Ok(listPlatformReadDto); 

            // return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));

            Console.WriteLine("--> Getting Platforms....");
            var platformItem = _repo.GetAllPlatforms();
            var platformReadDtoList = _mapper.Map<IEnumerable<PlatformReadDto>>(platformItem);

            return Ok(platformReadDtoList);
            //return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            // var platformItem = _repo.GetPlatformById(id);
            // if (platformItem != null)
            // {
            //     return Ok(new PlatformReadDto
            //     {
            //         Id = platformItem.Id,
            //         Name = platformItem.Name,
            //         Publisher = platformItem.Publisher,
            //         Cost = platformItem.Cost
            //     });
            // }
            // return NotFound();
            
            var platformItem = _repo.GetPlatformById(id);
            if (platformItem != null)
            {
                var platformReadDto = _mapper.Map<PlatformReadDto>(platformItem);
                return Ok(platformReadDto);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            // var platformModel = new Platform
            // {
            //     Name = platformCreateDto.Name,
            //     Publisher = platformCreateDto.Publisher,
            //     Cost = platformCreateDto.Cost
            // };
            // _repo.CreatePlatform(platformModel);
            // _repo.SaveChanges();

            // var platformReadDto = new PlatformReadDto
            // {
            //     Id = platformModel.Id,
            //     Name = platformModel.Name,
            //     Publisher = platformModel.Publisher,
            //     Cost = platformModel.Cost
            // };
            // return CreatedAtRoute(nameof(GetPlatformById),
            //     new { Id = platformReadDto.Id }, platformReadDto);

            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _repo.CreatePlatform(platformModel);
            _repo.SaveChanges();
            
            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronous data: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetPlatformById),
                new { Id = platformReadDto.Id }, platformReadDto);
        }
    }
}