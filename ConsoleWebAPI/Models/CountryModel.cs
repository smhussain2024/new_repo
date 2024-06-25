using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebAPI.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public int Population { get; set; }
      
        public int Area { get; set; }
    }
}
