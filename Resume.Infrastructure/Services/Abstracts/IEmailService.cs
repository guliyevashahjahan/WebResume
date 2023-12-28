using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services.Abstracts
{
    public interface IEmailService
    {
        Task<bool> SendMailAsync(string to, string subject, string body);
    }
}
