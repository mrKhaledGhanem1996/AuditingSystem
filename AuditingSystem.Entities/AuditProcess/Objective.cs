using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingSystem.Entities.AuditProcess
{
    public class Objective:Base
    {
        public int ActivityId { get; set; }
        public virtual Activity? Activity { get; set; }
        public virtual IEnumerable<Tasks>? Tasks { get; set; }
 
       
    }
}
