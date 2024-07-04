using Azure;
using ConsoleWebAPI.Models;
using ConsoleWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        /*[Route("{Id:int:min(10):max(100)}")]
        public string GetbyId(int Id)
        {
            return "hello int " + Id;
        }

        [Route("{Id:length(5):alpha:regex(aaaa(b|c))}")]
        public string GetbyId(string Id) 
        {
            return "hello string " + Id;
        }

        //Resolve the Service dependency directly in the Action Method
        [HttpGet("product")]
        public IActionResult GetName([FromServices] IProductRepository _productRepository1) {
            string name = _productRepository1.GetProductName();
            return Ok(name);
        }*/

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await this._bookRepository.GetAllBooksAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await this._bookRepository.GetBookByIdAsync(id);
            if(book == null) { return NotFound(); }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BooksModel booksModel)
        {
            var id = await this._bookRepository.AddBook(booksModel);
            //return CreatedAtAction(nameof(GetBookById), new { id = id }, booksModel);
            return CreatedAtAction(nameof(GetBookById), new { id = id, controller = "Books" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BooksModel booksModel)
        {
            await this._bookRepository.UpdateBookAsync(id, booksModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute] int id, [FromBody] JsonPatchDocument bookModel)
        {
            await this._bookRepository.UpdateBookPatchAsync(id, bookModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await this._bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}