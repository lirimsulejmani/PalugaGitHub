using DatabaseLayer.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public class DegreeProgramService : IDegreeProgramService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public DegreeProgramService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
