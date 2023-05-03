using Microsoft.AspNetCore.Mvc;
using WebApiMVC.Models;

namespace WebApiMVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IWebHostEnvironment _hosting;

        public ProfileController(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }
        [HttpPost]
        public async Task<Profile> Profile(string name, List<IFormFile> file)
        {
            var path = _hosting.WebRootPath + "/upload/";
            var profile = new Profile();
            profile.Name = name;

            if (file.Count > 0)
            {
                var fileTarget = path + file[0].FileName;
                using (var stream = new FileStream(fileTarget, FileMode.Create))
                {
                    await file[0].CopyToAsync(stream);
                }
                profile.Url = "upload/" + file[0].FileName;
            }
            return profile;
        }
    }
}
