using Acc.Core.Entities.Accounts;
using Acc.Infrastructure.DBContexts;
using Acc.Infrastructure.Repositories.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Infrastructure.Repositories.Accounts.Documents
{
   public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        private readonly AccDbContext context;
        public DocumentRepository(AccDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
