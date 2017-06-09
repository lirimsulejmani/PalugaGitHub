using ServiceLayer.DTO;
using System;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface ISellingBookService
    {
        Task<Guid> SellBookAsync(SellingBookDto dto);
    }
}