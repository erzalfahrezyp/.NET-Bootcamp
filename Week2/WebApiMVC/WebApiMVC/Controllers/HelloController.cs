using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMVC.Controllers
{
    [Route("api/[controller]/[action]")] // api/hello/<action>
    [ApiController] // based on
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string HelloGet() // http get
        {
            return "Hello World! - get";
        }
        [HttpPost]
        public string HelloPost() // http post
        {
            return "Hello World! - post";
        }
        [HttpPut]
        public string HelloPut() // http put
        {
            return "Hello World! - put";
        }
        [HttpDelete]
        public string HelloDelete() // http delete
        {
            return "Hello World! - delete";
        }
    }
}
