using Resume.Infrastructure.Commons.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Entities.Membership
{
    public class Education : BaseEntity<int>
    {
        public int EmployeeId { get; set; }
        public string Profession { get; set; }
        public string StudyPlace { get; set; }
        public string Duration { get; set; }
        
    }
}
