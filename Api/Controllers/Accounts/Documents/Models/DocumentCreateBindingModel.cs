using Acc.Core.Entities.Accounts;
using Core.Enums;

namespace Acc.Api.Controllers.Accounts.Documents.Models
{
    public class DocumentCreateBindingModel
    {
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
