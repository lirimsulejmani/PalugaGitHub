using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Goodreads.Models.Response;
using Microsoft.AspNetCore.Mvc;
using PalugaApi.Infrastructure.APIs;
using PalugaApi.Models;
using ServiceLayer.APIs.Google;
using ServiceLayer.Contracts;
using ServiceLayer.DTO;
using ServiceLayer.APIs.ComparePrices;

namespace PalugaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BooksController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly IStudentService _studentService;
        public BooksController(IMapper mapper, IBookService bookService,IStudentService studentService) : base(studentService)
        {
            _mapper = mapper;
            _bookService = bookService;
            _studentService = studentService;
        }

        // private readonly IBooksClient BooksClient;
        // GET: api/Books
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Books/searchText
        [HttpGet("[action]/{searchText}")]
        public async Task<IActionResult> SearchBooks(string searchText)
        {
            //scope = https://www.googleapis.com/auth/books
            //if the book is not found in database search in google books
            GoogleBookSearch books = new GoogleBookSearch("Paluga", "AIzaSyBd8Wo7uTz1_CNPSk_W0SAgy_Y5h8u10bQ");

            //  var results = await books.Search(searchText);

            //9781760553128
            var results = await books.SearchISBN(searchText);
            return Respond(results);
            //return Ok(new { SearchText = searchText, ISBN = "9781760553128", Title = "Google Book story" });
        }

        // GET: api/Books/searchText
        [HttpGet("[action]/{query}/{page?}")]
        public async Task<IActionResult> SearchOnGoodreadsByIsbn(string query)
        {
            var booksClient = GoodreadsHelper.GetClient().Books;
            //isbn: 0765326353
            var book = await booksClient.GetByIsbn(query);

            return Respond(book);
        }

        // GET: api/Books/searchText
        [HttpGet("[action]/{query}/{page?}")]
        public async Task<IActionResult> SearchOnGoodreads(string query, int page)
        {
            var booksClient = GoodreadsHelper.GetClient().Books;
            //isbn: 0765326353
            // var book = await BooksClient.GetByIsbn(searchText);
            var response = await booksClient.Search(query, page);
            //var list = _mapper.Map<List<BookViewModel>>(response.List);
            //var pagination = response.Pagination;

            //var bestBooks = result.List.Select(t => t.BestBook).ToList();
            //var booksBatches = Utilities.Split(bestBooks, 5);

            return Respond(response);
            /*return Respond(new {
                List = list,
                Pagination = pagination
            });*/
        }

        [HttpGet("[action]/{bookId}")]
        public async Task<IActionResult> SearchOnGoodreadsById(int bookId)
        {
            //check book in database first
            //var existingBook = this.bookService.GetByBookreadId(bookId);
            //if (existingBook != null)
            //{
            //    return Respond(existingBook);
            //}          
            
            //check book online
            var booksClient = GoodreadsHelper.GetClient().Books;
            var book = await booksClient.GetByBookId(bookId);
            //add book to database
            //var newBook = AutoMapper.Mapper.Map<BookViewModel>(book);
            //await AddBook(newBook);

            return Respond(book);
        }
        
        public async Task AddBook(BookViewModel model)
        {
            var newBook = _mapper.Map<AddBookDto>(model);

            /*var newBook = new ServiceLayer.DTO.AddBookDto
            {
                Isbn = model.Isbn,
                Isbn13 = model.Isbn13,
                Title = model.Title,
                OriginalTitle = model.OriginalTitle,
                Description = model.Description,
                Authors = model.Authors,
                Edition = model.Edition,
                Publisher = model.Publisher,
                PublicationDate = model.PublicationDate,
                Language = model.Language,
                ImageUrl = model.ImageUrl,
                Pages = model.Pages,
                GoodreadId = model.GoodreadId,
                Url = model.Url,
                EntryDate = model.EntryDate
            };*/

            await _bookService.AddBookAsync(newBook);
        }


        // GET: api/Books/searchText
        [HttpGet("[action]/{isbn}")]
        public async Task<IActionResult> CompareBookPrices(string isbn)
        {
            //if the book is not found in database search in google books
            BookFinderPrices prices = new BookFinderPrices(isbn);

            //9781760553128
            var results = await prices.GetComparePrices();
            return Respond(results);
            //return Ok(new { SearchText = searchText, ISBN = "9781760553128", Title = "Google Book story" });
        }


        // POST: api/Books
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
