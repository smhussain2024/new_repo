using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")] //base route
    public class EmployeeController : ControllerBase
    {
        public EmployeeController() { }

        //Multiple URL for single resource
        [Route("~/api/get-all-employee")]
        [Route("~/getall")]
        [Route("~/get-all")]
        //[Route("[controller]/[action]")] //Token Replacement in Routing
        public string GetAllEmployee() {
            return "Hello from get all employee";
        }

        [Route("api/get-all-auther")]
        [Route("[controller]/[action]")] //Token Replacement in Routing
        //[Route("get-all")] //this is not possible, cant have same URL for multiple resource
        public string GetAllAuthors()
        {
            return "Hello from get all authors";
        }

        //[Route("api/emplpoyee/{id}")]
        [Route("{id}")]
        public string GetEmployeeByID(int id) {
            return "Employee " + id;
        }

        [Route("api/emp/{emp_id}/author/{author_id}")]
        public string GetAuthorByID(int emp_id, int author_id)
        {
            return "Employee ID: " + emp_id + 
                "   Author ID: " + author_id;
        }

        [Route("search")]
        public string SearchEmployee(int emp_id, string name)
        {
            return "Employee ID: " + emp_id  +
                 " Employee Name: " + name;

        }
    }
}
