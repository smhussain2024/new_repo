using AutoMapper;
using ConsoleWebAPI.Data;
using ConsoleWebAPI.Models;

namespace ConsoleWebAPI.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BooksModel>().ReverseMap();
        }
    }
}
