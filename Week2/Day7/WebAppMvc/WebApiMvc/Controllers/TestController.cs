using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMvc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        public string Hello()
        {
            return "Hello - Public";
        }
        [HttpGet]
        [Authorize]
        public string Member()
        {
            return "Hello - Member";
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public string Manager()
        {
            return "Hello - Manager";
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public string Admin()
        {
            return "Hello - Admin";
        }
    }
}
