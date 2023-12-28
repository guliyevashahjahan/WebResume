using Resume.Infrastructure.Commons.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Entities.Membership
{
    public class Portfolio : BaseEntity<int>
    {
        public int EmployeeId { get; set; }
        public string ProjectName { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        
    }
}
