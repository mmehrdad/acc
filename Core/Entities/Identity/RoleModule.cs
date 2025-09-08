using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Identity
{
    public class RoleModule:BaseModel
    {
        public Module Module { get; set; }
        public string ModuleId { get; set; }
        public Role Role { get; set; }
        public string RoleId { get; set; }
        public virtual ICollection<RoleModulePermission> RoleModulePermissions { get; set; }
    }
}
