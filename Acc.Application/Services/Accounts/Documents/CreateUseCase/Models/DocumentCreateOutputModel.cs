using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Application.Services.Accounts.Documents.CreateUseCase.Models
{
   public class DocumentCreateOutputModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DocumentCreateOutputModelFields OutputModelFields { get; set; }
    }
}
