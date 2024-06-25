using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [Route("{Id:int:min(10):max(100)}")]
        public string GetbyId(int Id)
        {
            return "hello int " + Id;
        }

        [Route("{Id:length(5):alpha:regex(aaaa(b|c))}")]
        public string GetbyId(string Id) 
        {
            return "hello string " + Id;
        }
    }
}
