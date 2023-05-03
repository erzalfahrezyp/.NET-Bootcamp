using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class FormPendaftaranController : Controller
    {
        public IActionResult Registration()  
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(DataForm d) 
        {
            ViewBag.Judul = "Data yang sudah diterima";

            return View("RegistrationDetails", d);
        }
    }
}
