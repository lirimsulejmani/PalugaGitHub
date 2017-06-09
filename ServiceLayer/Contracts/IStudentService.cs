using System;
using System.Threading.Tasks;
using ServiceLayer.DTO;
using DatabaseLayer.Models;

namespace ServiceLayer.Contracts
{
    public interface IStudentService
    {
        Task<StudentDto> GetById(Guid id);
        Student GetByEmail(string email);
        Student GetByToken(string token);
        Student GetByTokenAndEmail(string token, string email);

        bool CheckCredits(string email, string password);
        void Activate(Student student);
        void UpdateProfile(UpdateProfileDto student);

        Task<Guid> CreateAsync(CreateStudentDto dto);
    }
}