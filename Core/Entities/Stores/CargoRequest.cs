using Acc.Core.Entities.Identity;
using Acc.Core.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class CargoRequest:BaseModel
    {
        public Person Requester { get; set; }
        public string RequesterId { get; set; }

        public Department Department { get; set; }
        public string DepartmentId { get; set; }

        public string RequestNo { get; set; }

        public User Approver { get; set; }
        public string? ApproverId { get; set; }
        public DateTime ApprovalDate { get; set; }

        public virtual ICollection<CargoRequestItem> CargoRequestItems { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
