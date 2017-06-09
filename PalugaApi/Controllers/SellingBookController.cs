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
using PalugaApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace PalugaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SellingBookController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISellingBookService _sellingBookService;
        private readonly IStudentService _studentService;
        private readonly IHostingEnvironment _appEnvironment;
        public SellingBookController(IMapper mapper, ISellingBookService sellingBookService, IStudentService studentService, IHostingEnvironment appEnvironment) : base(studentService)
        {
            _mapper = mapper;
            _sellingBookService = sellingBookService;
            _studentService = studentService;
            _appEnvironment = appEnvironment;
        }

        // POST: api/sellingBook
        //[NoCache]
        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Post([FromBody]SellingBookViewModel model)
        //{
        //    var student = await AuthUser();
        //    if (student == null)
        //        return Unauthorized();

        //    if (!model.BookConditionId.HasValue)
        //        return RespondWithError("Choose a book condition.", 422);

        //    if (!model.Price.HasValue)
        //        return RespondWithError("Give a price.", 422);


        //    var sellBook = new SellingBookDto()
        //    {
        //        //get srudent info from token
        //        StudentId = student.Id,
        //        BookId = model.BookId,
        //        Isbn10 = model.Isbn10,
        //        Isbn13 = model.Isbn13,
        //        BookConditionId =  model.BookConditionId.Value,
        //        Price = model.Price.Value,
        //        Comment = model.Comment
        //    };

        //    await _sellingBookService.SellBookAsync(sellBook);
        //    return Respond(sellBook);
        //}


        //Upload image
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    var savePath = Path.Combine(_appEnvironment.WebRootPath, "uploads", file.FileName);

                    using (var fileStream = new FileStream(savePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    return Created(savePath, file);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}