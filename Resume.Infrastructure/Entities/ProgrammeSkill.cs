﻿using Resume.Infrastructure.Commons.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Entities
{
    public class ProgrammeSkill : BaseEntity<int>
    {
        public int UserId { get; set; }
        public string Programme { get; set; }
        public int Percentage { get; set; }
    }
}