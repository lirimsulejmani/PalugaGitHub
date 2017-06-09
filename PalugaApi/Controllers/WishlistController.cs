using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PalugaApi.Infrastructure;
using PalugaApi.Models;
using ServiceLayer.Contracts;
using ServiceLayer.DTO;

namespace PalugaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WishlistController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IWishlistService _wishlistService;
        public WishlistController(IStudentService studentService, IWishlistService wishlistService, IMapper mapper) : base(studentService)
        {
            _mapper = mapper;
            _wishlistService = wishlistService;
        }

        [NoCache]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetList()
        {
            var student = await AuthUser();
            if (student == null)
                return Unauthorized();

            var list = await _wishlistService.GetList(student.Id);
            return Respond(list);
        }

        [NoCache]
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody]AddWishlistRequest model)
        {
            try
            {
                var student = await AuthUser();
                if (student == null)
                    return Unauthorized();

                var dto = _mapper.Map<AddWishlistDto>(model);
                dto.StudentId = student.Id;
                await _wishlistService.AddToListAsync(dto);
                return RespondSuccess("Book added to wishlist successfully.");
            }
            catch (InvalidOperationException)
            {
                return RespondBadRequest();
            }
        }

        [Authorize]
        [HttpGet("[action]/{isbn}")]
        public async Task<IActionResult> CheckBook(string isbn)
        {
            var isInWishlist = await _wishlistService.CheckBook(isbn);
            return Respond(isInWishlist);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _wishlistService.Delete(id);
                return RespondSuccess("Book deleted successfully from wishlist.");
            }
            catch (InvalidOperationException)
            {
                return RespondBadRequest();
            }
            
        }
    }
}