using DatabaseLayer.UoW;
using System;
using DatabaseLayer.Models;
using System.Threading.Tasks;
using ServiceLayer.DTO;
using System.Linq;
using AutoMapper;


namespace ServiceLayer.Contracts
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public BookService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
        }

        public async Task<Book> GetById(Guid id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return await unitOfWork.BookRepository.GetByIdAsync(id);
            }
        }

        public Book GetByBookreadId(int goodreadId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return unitOfWork.BookRepository.Query().FirstOrDefault(x => x.GoodreadId.Equals(goodreadId));
            }
        }

        public Book GetByISBN(string isbn)
        {
            using (var unitOfWork = this._unitOfWorkFactory.Create())
            {
                return unitOfWork.BookRepository.Query().FirstOrDefault(x => x.Isbn.Equals(isbn));
            }
        }

        public async Task<Guid> AddBookAsync(AddBookDto dto)
        {
            using (var unitOfWork = this._unitOfWorkFactory.Create())
            {
                var newBook = _mapper.Map<Book>(dto);

                /*var newBook = new Book
                {
                    Isbn = dto.Isbn,
                    Isbn13 = dto.Isbn13,
                    Title = dto.Title,
                    OriginalTitle = dto.OriginalTitle,
                    Description = dto.Description,
                    Authors = dto.Authors,
                    Edition = dto.Edition,
                    Publisher = dto.Publisher,
                    PublicationDate = dto.PublicationDate,
                    Language = dto.Language,
                    ImageUrl = dto.ImageUrl,
                    LargeImageUrl = dto.LargeImageUrl,
                    Pages = dto.Pages,
                    GoodreadId = dto.GoodreadId,
                    Url = dto.Url,
                    EntryDate = dto.EntryDate
                };*/
    

                unitOfWork.BookRepository.Add(newBook);
                await unitOfWork.CommitAsync();
                return newBook.Id;
            }
        }
        
    }
}
