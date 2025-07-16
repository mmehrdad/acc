using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class CargoRequestItem:BaseModel
    {
        Cargo Cargo { get; set; }
        string CargoId { get; set; }
        CargoRequest CargoRequest { get; set; }
        string CargoRequestId { get; set; }
    }
}
