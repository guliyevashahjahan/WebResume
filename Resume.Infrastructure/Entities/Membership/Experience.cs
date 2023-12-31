﻿using Resume.Infrastructure.Commons.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Entities.Membership
{
    public class Experience : BaseEntity<int>
    {
        public int EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
