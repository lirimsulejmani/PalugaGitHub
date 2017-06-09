using DatabaseLayer.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public class StudyCourseBookService : IStudyCourseBookService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public StudyCourseBookService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
