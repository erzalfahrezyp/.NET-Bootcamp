using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using CommandsService.SyncDataSevices;
using Microsoft.AspNetCore.Mvc;
// using CommandsService.Dtos;
// using CommandsService.Data;
// using CommandsService.Models;

namespace CommandsService.Controllers
{
    // [ApiController]
    // [Route("api/c/[controller]")]
    // public class PlatformsController : ControllerBase
    // {
    //     private readonly IPlatformRepo _platformRepo;

    //     public PlatformsController(IPlatformRepo platformRepo)
    //     {
    //         _platformRepo = platformRepo;
    //     }

    //     [HttpPost("Sync")]
    //     public async Task<ActionResult> SyncPlatforms()
    //     {
    //         try
    //         {
    //             await _platformRepo.CreatePlatform();
    //             return Ok("Platforms Synced");
    //         }
    //         catch (Exception ex)
    //         {
    //             return BadRequest($"Could not sync platforms: {ex.Message}");
    //         }
    //     }

    //     [HttpGet]
    //     public async Task<IEnumerable<PlatformReadDto>> GetPlatforms()
    //     {
    //         var platforms = await _platformRepo.GetAllPlatforms();
    //         return platforms.Select(p => new PlatformReadDto
    //         {
    //             Id = p.Id,
    //             Name = p.Name
    //         }).ToList();
    //     }
    //     [HttpPost]
    //     public async Task<ActionResult> TestInboundConnection(PlatformReadDto platformReadDto)
    //     {
    //         Console.WriteLine("--> Tambahkan platform baru");
    //         try
    //         {
    //             await _platformRepo.CreatePlatform(new Platform
    //             {
    //                 Id = platformReadDto.Id,
    //                 Name = platformReadDto.Name
    //             });
    //             return Ok(platformReadDto);
    //         }
    //         catch (System.Exception ex)
    //         {
    //             return BadRequest($"Could not add platform to the database: {ex.Message}");
    //         }
    //     }
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {

        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST Command Service");
            return Ok("Inbound test from Platforms Controller");
        }
    
        // [HttpPost]
        // public ActionResult TestInboundConnection()
        // {
        //     Console.WriteLine("--> Inbound POST Command Service");
        //     return Ok("Inbound test from Platforms Controller");
        // }

        // [HttpGet]
        // public string HelloWord()
        // {
        //     return "Hello Web API";
        // }
        // [HttpGet("hello")]
        // public string Hello()
        // {
        //     return "Hello Postman";
        // }
        // [HttpGet("{id}/{name}")]
        // public string GetPlatformById(int id, string name)
        // {
        //     return $"Platform with id {id} - {name}";
        // }
        // [HttpPost]
        // public ActionResult TestInboundConnection()
        // {
        //     Console.WriteLine("--> Inbound POST Command Service");
        //     return Ok("Inbound test from Platform Controller");
        // }
    }
}