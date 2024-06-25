using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsoleWebAPI.Models;
using System.Xml.Linq;


namespace ConsoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [Route("")]
        public CustomerModel GetCustomer()
        {
            return new CustomerModel() { Id = 1, Name = "salman" };
        }

        [Route("{Id}")]
        public IActionResult GetAllCustomers(int Id)
        {
            //Return mutltiple types of data from action method then use action result

            if (Id == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(new List<CustomerModel>()
                {
                    new CustomerModel() { Id = 1, Name = "salman" },
                    new CustomerModel() { Id = 2, Name = "abbas" }
                });
            }
        }

        [Route("{Id}/basic")]
        public ActionResult<CustomerModel> GetCustomerBasicDetails(int Id)
        {
            //Return mutltiple types of data from action method then use action result

            if (Id == 0)
            {
                return NotFound();
            }
            else
            {
                return new CustomerModel() { Id = 1, Name = "salman" };
            }
        }

        [Route("get-all-customer")]
        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            return new List<CustomerModel>()
            {
                new CustomerModel() { Id = 1, Name = "salman" },
                new CustomerModel() { Id = 2, Name = "abbas" }
            };
        }


    }
}
