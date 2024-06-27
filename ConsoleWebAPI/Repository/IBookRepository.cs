using ConsoleWebAPI.Models;

namespace ConsoleWebAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BooksModel>> GetAllBooksAsync();
    }
}