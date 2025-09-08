using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class CargoRequestItem : BaseModel
    {
        public Cargo Cargo { get; set; }
        public string CargoId { get; set; }
        public CargoRequest CargoRequest { get; set; }
        public string CargoRequestId { get; set; }
    }
}
