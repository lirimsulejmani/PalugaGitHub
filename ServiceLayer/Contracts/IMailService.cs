using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IMailService
    {
        Task SendMailAsync(string email, string subject, string message);
        Task SignUpMail(string email, string token);
    }
}
