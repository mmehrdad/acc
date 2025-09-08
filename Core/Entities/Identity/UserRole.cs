using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Identity
{
    public class UserRole : IdentityUserRole<string>
    {

        public User User { get; set; }

        public Role Role { get; set; }

    }
}
