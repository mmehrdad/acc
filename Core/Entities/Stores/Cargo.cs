using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class Cargo:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<CargoSpecific> CargoSpecifics { get; set; }
        public virtual ICollection<CargoStore> CargoStores { get; set; }
        public virtual ICollection<CargoFactor> CargoFactors { get; set; }
        public virtual ICollection<CargoRequestItem> CargoRequestItems { get; set; }
    }
}
