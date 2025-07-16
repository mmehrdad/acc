using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class TransactionItem:BaseModel
    {
        public Transaction Transaction { get; set; }
        public string TransactionId { get; set; }
    }
}
