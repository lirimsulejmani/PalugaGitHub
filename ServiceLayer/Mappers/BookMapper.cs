using System.Linq;
using AutoMapper;
using DatabaseLayer.Models;
using ServiceLayer.DTO;

namespace ServiceLayer.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>()
                .BeforeMap((src, dest) => dest.Authors = src.Authors.First().Name);
        }
    }
}
