using DatabaseLayer.Models;
using DatabaseLayer.UoW;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public class SchoolService : ISchoolService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public SchoolService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<School>> GetList()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return await unitOfWork.SchoolRepository.Query().ToAsyncEnumerable().ToList();
            }
        }

        public async Task SeedSchools()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.SchoolRepository.Add(new School() { Id = Guid.NewGuid(), Name = "Universität Zürich" });
                unitOfWork.SchoolRepository.Add(new School() { Id = Guid.NewGuid(), Name = "ETH Zürich" });
                unitOfWork.SchoolRepository.Add(new School() { Id = Guid.NewGuid(), Name = "Zürcher Hochschule für Angewandte Wissenschaften(ZHAW)" });
                unitOfWork.SchoolRepository.Add(new School() { Id = Guid.NewGuid(), Name = "Hochschule für Wirtschaft Zürich(HWZ)" });
                unitOfWork.SchoolRepository.Add(new School() { Id = Guid.NewGuid(), Name = "Pädagogische Hochschule Zürich(PHZH)" });
                unitOfWork.SchoolRepository.Add(new School() { Id = Guid.NewGuid(), Name = "Hochschule Rapperswil(HSR)" });
                unitOfWork.SchoolRepository.Add(new School() { Id = Guid.NewGuid(), Name = "Zürcher Hochschule der Künste(ZHdK)" });
                unitOfWork.SchoolRepository.Add(new School() { Id = Guid.NewGuid(), Name = "Hochschule Luzern(HSLU)" });
                unitOfWork.SchoolRepository.Add(new School() { Id = Guid.NewGuid(), Name = "Universität St.Gallen" });
                await unitOfWork.CommitAsync();
            }
        }

    }
}
