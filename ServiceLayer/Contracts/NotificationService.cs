using DatabaseLayer.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Contracts
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public NotificationService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
