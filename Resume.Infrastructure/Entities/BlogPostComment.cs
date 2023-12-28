using Resume.Infrastructure.Commons.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Entities
{
    public class BlogPostComment : BaseEntity<int>
    {
        public string Comment { get; set; }
        public int? ParentId { get; set; }
        public int PostId { get; set; }
    }
}
