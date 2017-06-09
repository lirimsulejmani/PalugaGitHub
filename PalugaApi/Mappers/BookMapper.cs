using AutoMapper;
using Goodreads.Models.Response;
using PalugaApi.Models;
using ServiceLayer.DTO;

namespace PalugaApi.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<BookViewModel, BookDto>();
            CreateMap<AuthorViewModel, AuthorDto>();
            CreateMap<Work, BookViewModel>();
        }
    }
}
