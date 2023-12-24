using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingSystem.Entities.AuditProcess
{
    public class Activity:Base
    {
        public int FunctionId { get; set; }
        public virtual Function? Function { get; set; }
        public virtual IEnumerable<Objective>? Objectives { get; set; }

  

    }
}
