using ConsoleWebAPI.Binders;
using ConsoleWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[BindProperties(SupportsGet = true)]
    public class CountriesController : ControllerBase
    {
        /*[BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Population { get; set; }

        [BindProperty]
        public string Area { get; set; }*/

        //[BindProperty(SupportsGet=true)]
        public CountryModel Country { get; set; }

        [HttpPost("")]
        public IActionResult AddCountry()
        {
            return Ok($"Name: {this.Country.Name}, " +
                $"Population: {this.Country.Population}, " +
                $"Area: {this.Country.Area}");
        }

        [HttpPost("FromQuery")]
        public IActionResult FromQuery([FromQuery]int Id, [FromQuery]CountryModel country)
        
        {
            return Ok($"ID: {Id}, " +
                $"Name: {country.Name}, " +
                $"Population: {country.Population}, " +
                $"Area: {country.Area}");
        }

        [HttpPost("{id}")]
        public IActionResult AddCountry([FromRoute]int id, [FromForm]CountryModel country, 
            [FromHeader] string developer, [FromHeader] string version_no)
        {
            return Ok($"Name = {country.Name}, Id = {id}");
        }

        [HttpGet("search")]
        public IActionResult Search([ModelBinder(typeof(CustomBinder))] string[] countries) {
            return Ok(countries);
        }

        [HttpGet("{id}/{ddd}")]
        public IActionResult CountryDetails([ModelBinder(typeof(CustomeBinderCountryDetails), Name = "id")] CountryModel country)
        {
            return Ok(country);
        }


    }
}
