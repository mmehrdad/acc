using Acc.Core.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Application.Services.Accounts.Documents.GetUseCase
{
    public interface IDocumentGetUseCase
    {
        Document GetByDocumentNo(string documentNo);
        IQueryable<Document> GetByDocumentDate(DateOnly documentDate);
    }
}
