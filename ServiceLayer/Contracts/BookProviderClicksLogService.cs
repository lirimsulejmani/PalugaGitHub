using DatabaseLayer.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public class BookProviderClicksLogService : IBookProviderClicksLogService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public BookProviderClicksLogService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
