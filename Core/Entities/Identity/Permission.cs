using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Identity
{
    public class Permission:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<RoleModulePermission> RoleMadulePermissions { get; set; }
    }
}
