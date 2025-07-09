using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Identity
{
    public class Module:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<RoleModule> RoleModules { get; set; }
    }
}
