using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services.Configurations
{
    public class CryptoOptions
    {
        public string SaltKey { get; set; }
        public string SymmetricKey { get; set; }
    }
}
