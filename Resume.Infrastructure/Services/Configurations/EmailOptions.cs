using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services.Configurations
{
    public class EmailOptions
    {
        public string DisplayName { get; set; }
        public string SmtpServer { get; set; }
        public short SmtpPort { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
