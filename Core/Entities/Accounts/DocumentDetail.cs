using Acc.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Accounts
{
    public class DocumentDetail:BaseModel
    {
        public Document Document { get; set; }
        public string DocumentId { get; set; }

        public Account Account { get; set; }
        public string AccountId { get; set; }

        public DocumentDetail Reference { get; set; }
        public string ReferenceId { get; set; }


        public decimal Price { get; set; }
        public AccountType AccountType { get; set; }
        public string Description { get; set; }
        public ICollection<DocumentDetail> References { get; set; }
    }
}
