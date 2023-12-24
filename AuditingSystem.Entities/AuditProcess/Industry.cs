using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingSystem.Entities.AuditProcess
{
    public class Industry: Base
    {
        public int ParentIndustryId { get; set; } 
        public virtual Industry? ParentIndustry { get; set; }
        public virtual IEnumerable<Company>? Companies { get; set; }

        
    }
}
