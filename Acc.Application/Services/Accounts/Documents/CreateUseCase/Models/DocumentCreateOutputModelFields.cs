using Acc.Core.Entities.Accounts;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Application.Services.Accounts.Documents.CreateUseCase.Models
{
   public class DocumentCreateOutputModelFields
    {
        public string Id { get; set; }
        public string DocumentNo { get; set; }
        public DateOnly DocumentDate { get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }

        public string ReferenceId { get; set; }

        public string FinancialPeriodId { get; set; }

        public string CostCenterId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<DocumentDetail> DocumentDetails { get; set; }
        public virtual ICollection<Document> References { get; set; }
    }
}
