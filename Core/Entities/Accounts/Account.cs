using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Accounts
{
    public class Account:BaseModel
    {
        public string AccountNo { get; set; }
        public Account Parent { get; set; }
        public string ParentId { get; set; }
        public int AccountType { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }

        public ICollection<Account> ChildAccounts { get; set; }
    }
}
