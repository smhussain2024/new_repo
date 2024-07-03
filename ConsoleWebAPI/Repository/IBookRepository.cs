using Azure;
using ConsoleWebAPI.Models;

namespace ConsoleWebAPI.Repository
{
    public interface IBookRepository
    {
        Task<int> AddBook(BooksModel bookModel);
        Task DeleteBookAsync(int bookId);
        Task<List<BooksModel>> GetAllBooksAsync();
        Task<BooksModel> GetBookByIdAsync(int bookId);
        Task UpdateBookAsync(int bookId, BooksModel booksModel);
        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument booksModel);
    }
}