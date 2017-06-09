using DatabaseLayer.Models;
using DatabaseLayer.UoW;
using ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ServiceLayer.Contracts
{
    public class SellingBookService : ISellingBookService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public SellingBookService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Guid> SellBookAsync(SellingBookDto dto)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                var student = await unitOfWork.StudentRepository.GetByIdAsync(dto.StudentId);
                var sellBook = new SellingBook
                {
                    Student = student,
                    BookId = dto.BookId,
                    Isbn10 = dto.Isbn10,
                    Isbn13 = dto.Isbn13,
                    BookCondition = (BookConditionEnum)dto.BookConditionId,
                    Price = dto.Price,
                    Comment = dto.Comment
                };

                unitOfWork.SellingBookRepository.Add(sellBook);
                await unitOfWork.CommitAsync();
                return sellBook.Id;
            }
        }
    }
}
