using Acc.Api.Controllers.Accounts.Documents.Models;
using Acc.Api.Utilities;
using Acc.Application.Services.Accounts.Documents.CreateUseCase.Models;
using Acc.Core.Entities.Accounts;
using Acc.Core.Entities.Persons;

namespace Acc.Api.Controllers.Accounts.Documents
{
    public class DocumentAutoMapping : DefaultProfile
    {
        public DocumentAutoMapping()
        {
            CreateMap<DocumentCreateBindingModel, DocumentCreateInputModel>().ReverseMap();
            CreateMap<Document, DocumentCreateInputModel>().ReverseMap();
            CreateMap<DocumentCreateViewModel, DocumentCreateOutputModelFields>().ReverseMap();
            CreateMap<Document, DocumentCreateOutputModelFields>().ReverseMap();

            //CreateMap<DocumentUpdateBindingModel, DocumentUpdateInputModel>().ReverseMap();
            //CreateMap<Document, DocumentUpdateInputModel>().ReverseMap();
            //CreateMap<DocumentUpdateViewModel, DocumentUpdateOutputModelFields>().ReverseMap();
            //CreateMap<Document, DocumentUpdateOutputModelFields>().ReverseMap();

        }
    }
}
