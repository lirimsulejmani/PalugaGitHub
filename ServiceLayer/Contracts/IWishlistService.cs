using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayer.Models;
using ServiceLayer.DTO;

namespace ServiceLayer.Contracts
{
    public interface IWishlistService
    {
        Task<List<WishlistDto>> GetList(Guid studentId);
        Task<Guid> AddToListAsync(AddWishlistDto dto);
        Task<bool> CheckBook(string isbn);
        Task<bool> Delete(Guid id);
    }
}