using Acc.Application.Services.Accounts.Documents.CreateUseCase;
using Acc.Application.Services.Accounts.Documents.CreateUseCase.Models;
using Acc.Core.Entities.Accounts;
using Acc.Infrastructure.Helper;
using Acc.Infrastructure.Repositories.Accounts.Documents;
using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Application.Services.Documents.Documents.CreateUseCase
{
   public class DocumentCreateUseCase : IDocumentCreateUseCase
    {
        private readonly IDocumentRepository _documentRepository;
        //private readonly IUserInformationProvider userInformationProvider;
        private readonly IMapper _mapper;
        public DocumentCreateUseCase(IDocumentRepository documentRepository,
            IMapper mapper,
            IUserInformationProvider userInformationProvider
            )
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
            //this.userInformationProvider = userInformationProvider;
        }
        public async Task<DocumentCreateOutputModel> AddDocument(DocumentCreateInputModel inputModel, CancellationToken token)
        {
            var document = _mapper.Map<Document>(inputModel);
            await _documentRepository.AddAsync(document, token);
            var result = await _documentRepository.SaveChangesAsync(token);
            if (result > 0)
                return new DocumentCreateOutputModel
                {
                    IsSuccess = true,
                    Message = "",
                    OutputModelFields = _mapper.Map<DocumentCreateOutputModelFields>(document)
                };
            else
            {
                //Log.Information("User {Username} logged in  Message: {Message}", userInformationProvider.CurrentUserName,
                //   "خطا در ایجاد نوع بلوک .");

                return new DocumentCreateOutputModel
                {
                    IsSuccess = true,
                    Message = "خطا در ایجاد نوع بلوک",
                };
            }
            return null;
        }
    }
}
