using DatabaseLayer.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTO;

namespace ServiceLayer.Contracts
{
    public class WishlistService : IWishlistService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public WishlistService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
        }

        public async Task<List<WishlistDto>> GetList(Guid studentId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var list = await unitOfWork.WishlistRepository.FindAsync(x => x.Student.Id == studentId);
                return _mapper.Map<List<WishlistDto>>(list);
            }
        }

        public async Task<Guid> AddToListAsync(AddWishlistDto dto)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var student = await unitOfWork.StudentRepository.GetByIdAsync(dto.StudentId);
                var model = new Wishlist()
                {
                    BookISBN10 = dto.BookISBN10,
                    BookISBN13 = dto.BookISBN13,
                    Student = student,
                    EntryDate = DateTime.Now,
                    NotifiedStatus = NotifiedStatusEnum.Pending
                };

                unitOfWork.WishlistRepository.Add(model);
                await unitOfWork.CommitAsync();

                return model.Id;
            }
        }

        public async Task<bool> CheckBook(string isbn)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return await unitOfWork.WishlistRepository.SingleOrDefaultAsync(x => x.BookISBN13 == isbn) != null;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var wishlist = await unitOfWork.WishlistRepository.GetByIdAsync(id);
                if(wishlist != null)
                    unitOfWork.WishlistRepository.Delete(id);
                await unitOfWork.CommitAsync();
                return true;
            }
        }
    }
}
