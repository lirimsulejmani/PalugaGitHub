using DatabaseLayer.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using ServiceLayer.DTO;
using System.Threading.Tasks;
using DatabaseLayer.Models;
using ServiceLayer.Converters;

namespace ServiceLayer.Contracts
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public UserService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Guid> AddNewAsync(CreateUserDto dto)
        {
            using (var unitOfWork = this.unitOfWorkFactory.Create())
            {
                var school = await unitOfWork.SchoolRepository.GetByIdAsync(dto.SchoolId);

                var model = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password,
                    School = school
                };

                unitOfWork.UserRepository.Add(model);
                await unitOfWork.CommitAsync();
                return model.Id;
            }
        }

        public List<UserFlatDto> GetList()
        {
            using (var unitOfWork = this.unitOfWorkFactory.Create())
            {
                var result = unitOfWork.UserRepository.Query().ToList();
                return result.Select(UserConverter.ToFlatDto).ToList();
            }
        }
    }
}
