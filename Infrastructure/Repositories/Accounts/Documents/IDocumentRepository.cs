using Acc.Core.Entities.Accounts;
using Acc.Infrastructure.Repositories.Bases;
using Acc.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Infrastructure.Repositories.Accounts.Documents
{
    public interface IDocumentRepository : IBaseRepository<Document>, IScopedDependency
    {
    }
}
