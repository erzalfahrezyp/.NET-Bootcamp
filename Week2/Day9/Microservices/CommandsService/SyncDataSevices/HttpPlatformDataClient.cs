// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using System.Text.Json;
// using CommandsService.Dtos;

// namespace CommandsService.SyncDataSevices
// {
//     public class HttpPlatformDataClient : IPlatformDataClient
//     {
//         private readonly HttpClient _httpClient;
//         private readonly IConfiguration _configuration;
//         public HttpPlatformDataClient(HttpClient httpClient, IConfiguration configuration)
//         {
//             _httpClient = httpClient;
//             _configuration = configuration;
//         }
//         public async Task<IEnumerable<PlatformReadDto>> ReturnAllPlatforms()
//         {
//             var response = await _httpClient.GetAsync(_configuration["PlatformService"]);
//             if (response.IsSuccessStatusCode)
//             {

//                 var content = await response.Content.ReadAsStringAsync();
//                 Console.WriteLine($"{content}");
//                 var platforms = JsonSerializer.Deserialize<List<PlatformReadDto>>(content);
//                 if (platforms != null)
//                 {
//                     Console.WriteLine($"{platforms.Count()} platforms returned from Platforms Service");
//                     return platforms;
//                 }
//                 throw new Exception("No platforms found");
//             }
//             else
//             {
//                 throw new Exception("Unable to reach Platforms Service");
//             }
//         }
//         // public async Task<IEnumerable<PlatformReadDto>> ReturnAllPlatforms()
//         // {
//         //     var response = await _httpClient.GetAsync("http://localhost:6000/api/platforms");
//         //     if (response.IsSuccessStatusCode)
//         //     {

//         //         var content = await response.Content.ReadAsStringAsync();
//         //         Console.WriteLine($"{content}");
//         //         var platforms = JsonSerializer.Deserialize<List<PlatformReadDto>>(content).ToList();
//         //         if (platforms != null)
//         //         {
//         //             Console.WriteLine($"{platforms.Count()} platforms returned from Platforms Service");
//         //             return platforms;
//         //         }
//         //         throw new Exception("No platforms found");
//         //     }
//         //     else
//         //     {
//         //         throw new Exception("Unable to reach Platforms Service");
//         //     }
//         // }
//     }
// }