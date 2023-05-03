using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMvc.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
