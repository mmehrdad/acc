using Acc.Core.Entities.Accounts;
using Acc.Infrastructure.Helper;
using Acc.Infrastructure.Repositories.Accounts.Documents;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Application.Services.Accounts.Documents.GetUseCase
{
   public class DocumentGetUseCase : IDocumentGetUseCase
    {
        private readonly Lazy<IDocumentRepository> _documentRepository;
        private readonly IUserInformationProvider userInformationProvider;
        private readonly IMapper _mapper;
        public DocumentGetUseCase(Lazy<IDocumentRepository> documentRepository,
            IMapper mapper,
            IUserInformationProvider userInformationProvider
            )
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
            this.userInformationProvider = userInformationProvider;
        }
        public IQueryable<Document> GetDocument()
        {
            return _documentRepository.Value.GetAllAsNoTracking();
            // .Include(p=>p.DocumentSide);
        }
        public Document GetByDocumentNo(string documentNo)
        {
            return _documentRepository.Value.GetAllAsNoTracking()
                .FirstOrDefault(p => p.DocumentNo == documentNo);
        }
        public IQueryable<Document> GetByDocumentDate(DateOnly documentDate)
        {
            return _documentRepository.Value.GetAllAsNoTracking()
                .Where(p => p.DocumentDate == documentDate).ToList().AsQueryable();
        }

    }
}
