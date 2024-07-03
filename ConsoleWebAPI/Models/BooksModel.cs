using System.ComponentModel.DataAnnotations;

namespace ConsoleWebAPI.Models
{
    public class BooksModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter book title")]
        public string Title { get; set; } = string.Empty;
       [Required(ErrorMessage = "Please enter book description")]
        public string Description { get; set; } = string.Empty;
    }
}
