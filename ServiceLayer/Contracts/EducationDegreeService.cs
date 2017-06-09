using DatabaseLayer.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public class EducationDegreeService : IEducationDegreeService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public EducationDegreeService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
