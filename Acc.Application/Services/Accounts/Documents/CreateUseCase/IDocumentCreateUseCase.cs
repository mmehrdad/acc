using Acc.Application.Services.Accounts.Documents.CreateUseCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Application.Services.Accounts.Documents.CreateUseCase
{
   public interface IDocumentCreateUseCase
    {
        Task<DocumentCreateOutputModel> AddDocument(DocumentCreateInputModel inputModel, CancellationToken token);
    }
}
