using Resume.Infrastructure.Commons.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Entities
{
    public class BlogPost : BaseEntity<int>
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
    }
}

