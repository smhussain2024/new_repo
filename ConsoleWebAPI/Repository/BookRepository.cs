using Azure;
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

        public async Task<BooksModel> GetBookByIdAsync(int bookId)
        {
            var records = await this._context.Books.Where(
                x => x.Id == bookId).Select(x => new BooksModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,

                }).FirstOrDefaultAsync();

            return records;
        }

        public async Task<int> AddBook(BooksModel bookModel)
        {
            Books book = new Books()
            {
                Title = bookModel.Title, 
                Description = bookModel.Description
            };

            this._context.Books.Add(book);
            await this._context.SaveChangesAsync();

            return book.Id;
        }

        public async Task UpdateBookAsync(int bookId, BooksModel booksModel)
        {
            //var book = await this._context.Books.FindAsync(bookId);

            //if (book != null)
            //{
            //    book.Title = booksModel.Title;
            //    book.Description = booksModel.Description;
            //    await this._context.SaveChangesAsync();
            //}

            Books book = new Books()
            {
                Id = bookId,
                Title = booksModel.Title,
                Description = booksModel.Description
            };

            this._context.Update(book);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument booksModel)
        {
            var book = await this._context.Books.FindAsync(bookId);
            if (book != null)
            {
                booksModel.AppendReplace<Books>("title", book);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            //Here we are hitting the database two time (first to get the record and send to write chnages in database)
            /*var book = await this._context.Books.Where(x => x.Id == bookId).FirstOrDefaultAsync();
            this._context.Books.Remove(book);
            await this._context.SaveChangesAsync();*/
            
            Books book = new Books()
            {
               Id=bookId,
            };

            this._context.Remove(book);
            await this._context.SaveChangesAsync();
        }
    }
}
