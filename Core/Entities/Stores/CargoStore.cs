using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class CargoStore:BaseModel
    {
        public virtual Store Store { get; set; }
        public string StoreId { get; set; }

        public virtual Cargo Cargo { get; set; }
        public string CargoId { get; set; }

        public virtual CargoLocation CargoLocation { get; set; }
        public string CargoLocationId { get; set; }

        public int Number {  get; set; }
        public string[] Serials { get; set; }
    }
}
