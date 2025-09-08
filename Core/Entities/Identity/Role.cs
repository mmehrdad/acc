using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Identity
{
    public class Role: IdentityRole<string>
    {
        public string Name { get; set; }
        public ICollection<UserRole> Users { get; set; }
        public virtual ICollection<RoleModule> RoleModules { get; set; }
    }
}
