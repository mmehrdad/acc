using Acc.Core.Entities.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Persons
{
    public class Department:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<CargoRequest> CargoRequests { get; set; }
    }
}
