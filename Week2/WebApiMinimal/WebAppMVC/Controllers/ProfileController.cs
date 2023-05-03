using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IWebHostEnvironment _hosting;

        public ProfileController(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string name, List<IFormFile> file)
        {
            var path = _hosting.WebRootPath + "/upload/";
            var profile = new Profile();
            profile.Name = name;

            if(file.Count > 0) 
            {
                var fileTarget = path + file[0].FileName;
                using (var stream = new FileStream(fileTarget, FileMode.Create))
                {
                    await file[0].CopyToAsync(stream);
                }
                profile.Url = "upload/" + file[0].FileName;
                //file[0].
            }

            return View("Profile", profile);
        }
    }
}
