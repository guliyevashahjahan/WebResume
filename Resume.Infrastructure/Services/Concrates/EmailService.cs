using Microsoft.Extensions.Options;
using Resume.Infrastructure.Services.Abstracts;
using Resume.Infrastructure.Services.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services.Concrates
{
    public class EmailService : SmtpClient, IEmailService
    {
        readonly EmailOptions options;

        public EmailService(IOptions<EmailOptions> options)
        {
            this.options = options.Value;

            this.Host = this.options.SmtpServer;
            this.Port = this.options.SmtpPort;

            this.EnableSsl = true;
            this.Credentials = new NetworkCredential(this.options.UserEmail, this.options.Password);
        }

        public async Task<bool> SendMailAsync(string to, string subject, string body)
        {
            try
            {

                using (MailMessage message = new MailMessage())
                {

                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.To.Add(to);
                    message.From = new MailAddress(options.UserEmail, options.DisplayName);

                    await base.SendMailAsync(message);

                }

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
