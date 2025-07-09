using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Identity
{
    public class RoleModule:BaseModel
    {
        public Module Mudule { get; set; }
        public string MaduleId { get; set; }
        public Role Role { get; set; }
        public string RoleId { get; set; }
        public virtual ICollection<RoleModulePermission> RoleModulePermissions { get; set; }
    }
}
