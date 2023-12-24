using AuditingSystem.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingSystem.Entities.AuditProcess
{
    public class Department : Base
    {
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }

        public virtual IEnumerable<User>? Users { get; set; }
        public virtual IEnumerable<Function>? Functions { get; set; }
   
    }
}
