using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services.Concrates
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime ExecutingTime
        {
            get
            {
                return DateTime.Now;
            }
        }

    }
    public class UtcDateTimeService : IDateTimeService
    {
        public DateTime ExecutingTime
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

    }
}
