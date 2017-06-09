using DatabaseLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface ISchoolService
    {
        Task SeedSchools();
        Task<List<School>> GetList();
    }
}