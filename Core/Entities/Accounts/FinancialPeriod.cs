using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Accounts
{
    public class FinancialPeriod:BaseModel
    {
        public DateOnly StartDate {  get; set; }
        public DateOnly EndDate { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
