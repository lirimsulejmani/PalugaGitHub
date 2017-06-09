using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Models;
using ServiceLayer.DTO;

namespace ServiceLayer.Contracts
{
    public interface IBookService
    {
        Task<Book> GetById(Guid Id);
        Book GetByBookreadId(int goodreadId);
        Book GetByISBN(string Isbn);
        Task<Guid> AddBookAsync(AddBookDto dto);
    }
}
