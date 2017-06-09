using DatabaseLayer.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public RatingService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
