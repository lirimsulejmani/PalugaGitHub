using ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IUserService
    {
        List<UserFlatDto> GetList();
        Task<Guid> AddNewAsync(CreateUserDto user);
    }
}
