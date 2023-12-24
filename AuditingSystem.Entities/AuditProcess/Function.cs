using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingSystem.Entities.AuditProcess
{
    public class Function:Base
    {
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual IEnumerable<Activity>? Activities { get; set; }

    
    }
}
