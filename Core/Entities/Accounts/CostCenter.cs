using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Accounts
{
    public class CostCenter
    {
        public virtual ICollection<Document> Documents { get; set; }

    }
}
