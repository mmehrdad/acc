﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Identity
{
    public class RoleModulePermission : BaseModel
    {
        public RoleModule RoleMudule { get; set; }
        public string RoleMaduleId { get; set; }
        public Permission Permission { get; set; }
        public string PermissionId { get; set; }
    }
}
