using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class Transaction:BaseModel
    {
        public CargoRequest CargoRequest { get; set; }
        public string CargoRequestId { get; set; }
        public ICollection<TransactionItem> TransactionItems { get; set; }
    }
}
