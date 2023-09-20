using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogic.Interfaces
{
    public interface IMailService
    {
        Task SendMailAsync(string subject, string body, string toSend, string? fromSend = null);
    }
}
