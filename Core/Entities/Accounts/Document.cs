using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Accounts
{
    public class Document:BaseModel
    {
        public string DocumentNo { get; set; }
        public DateOnly DocumentDate {  get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }

        public FinancialPeriod FinancialPeriod { get; set; }
        public string FinancialPeriodId { get; set; }

        public CostCenter CostCenter { get; set; }
        public string CostCenterId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<DocumentDetail> DocumentDetails { get; set; }
    }
}
