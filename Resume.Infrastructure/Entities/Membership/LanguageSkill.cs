using Resume.Infrastructure.Commons.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Entities.Membership
{
    public class LanguageSkill : BaseEntity<int>
    {
        public int EmployeeId { get; set; }
        public string Language { get; set; }
        public int Percentage { get; set; }
    }
}
