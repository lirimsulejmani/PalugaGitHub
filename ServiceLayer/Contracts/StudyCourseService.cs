using DatabaseLayer.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public class StudyCourseService : IStudyCourseService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public StudyCourseService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
