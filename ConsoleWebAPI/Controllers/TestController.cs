using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebAPI.Controllers
{
    [ApiController]
    [Route("test/[action]")]
    public class TestController : ControllerBase
    {
        public string Get() {
            return "hello from test controller";
        }

        public string Get1()
        {
            return "hello from test controller get1()";
        }
    }
}
