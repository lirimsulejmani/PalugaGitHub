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
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ISecurityService _securityService;

        public StudentService(IUnitOfWorkFactory unitOfWorkFactory, ISecurityService securityService, IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _securityService = securityService;
            _mapper = mapper;
        }

        public async Task<StudentDto> GetById(Guid id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var student =  await unitOfWork.StudentRepository.SingleOrDefaultAsync(x => x.Id == id, x => x.School, x => x.EducationDegree);
                return _mapper.Map<StudentDto>(student);
            }
        }

        public Student GetByEmail(string email)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return unitOfWork.StudentRepository.Query().FirstOrDefault(x => x.Email.Equals(email));                
            }
        }

        public Student GetByToken(string token)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return unitOfWork.StudentRepository.Query().FirstOrDefault(x => x.ApiToken.Equals(token) 
                            && x.Active == false);
            }
        }

        public Student GetByTokenAndEmail(string token, string email)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return unitOfWork.StudentRepository.Query().First(x => x.ApiToken.Equals(token) && x.Email.Equals(email) && !x.Active);               
            }
        }

        public bool CheckCredits(string email, string password)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return unitOfWork.StudentRepository.Query().Any(x => x.Email.Equals(email) && this._securityService.Decrypt(x.Password).Equals(password) && x.Active);
            }
        }

        public void Activate(Student student)
        {
            student.Active = true;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                unitOfWork.StudentRepository.Update(student);
                unitOfWork.Commit();
            }
        }

        public async Task<Guid> CreateAsync(CreateStudentDto dto)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var school = await unitOfWork.SchoolRepository.GetByIdAsync(dto.SchoolId);

                var student = new Student
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password,
                    ApiToken = dto.ApiToken,
                    School = school
                };

                unitOfWork.StudentRepository.Add(student);
                await unitOfWork.CommitAsync();
                return student.Id;
            }
        }

        public async void UpdateProfile(UpdateProfileDto profile)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var student = await unitOfWork.StudentRepository.SingleOrDefaultAsync(x => x.Id == profile.Id, x => x.School, x => x.EducationDegree);
                
                var model = _mapper.Map(profile, student);
                if (profile.SchoolId != Guid.Empty)
                    model.School = await unitOfWork.SchoolRepository.GetByIdAsync(profile.SchoolId);

                if (model.EducationDegree != null && model.EducationDegree.Id != profile.EducationDegreeId)
                    model.EducationDegree =
                        await unitOfWork.EducationDegreeRepository.GetByIdAsync(profile.EducationDegreeId);

                unitOfWork.StudentRepository.Update(model);
                unitOfWork.Commit();
            }
        }
    }
}
