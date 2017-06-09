using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paluga.Infrastructure;
using ServiceLayer.APIs.Google;

namespace Paluga.Controllers
{
    [Produces("application/json")]
    //[Route("api/Books")]
    [Route("api/[controller]")] 
    public class BooksController : Controller
    {
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
        public IActionResult SearchBooks(string searchText)
        {
            //if the book is not found in database search in google books
            GoogleBookSearch books = new GoogleBookSearch("Paluga", "AIzaSyBd8Wo7uTz1_CNPSk_W0SAgy_Y5h8u10bQ");

            var results = books.Search(searchText);

            return Ok(new { SearchText = searchText , ISBN = "123456", Title = "Business Adventures"});
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
