using ConsoleWebAPI.Data;
using ConsoleWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleWebAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            this._context = context;
        }

        public async Task<List<BooksModel>> GetAllBooksAsync()
        {
            var records = await this._context.Books.Select(x => new BooksModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,

            }).ToListAsync();

            return records;
        }
    }
}
