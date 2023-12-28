﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Commons.Abstracts
{
    public interface IAuditableEntity 
    {
        int? CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        int? LastModifiedBy { get; set; }
        DateTime? LastModifiedAt { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
