using Acc.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class CargoLocation:BaseModel
    {
        public Store Store { get; set; }
        public string StoreId { get; set; }
        public string Name { get; set; }
        public LocationType LocationType { get; set; }
    }
}
