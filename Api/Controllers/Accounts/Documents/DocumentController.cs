using Acc.Api.Controllers.Accounts.Documents.Models;
using Acc.Application.Services.Accounts.Documents.CreateUseCase;
using Acc.Application.Services.Accounts.Documents.CreateUseCase.Models;
using Acc.Application.Services.Accounts.Documents.GetUseCase;
using Acc.Core.Entities.Accounts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Acc.Api.Controllers.Accounts.Documents
{
    public class DocumentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDocumentCreateUseCase _documentCreateUseCase;
        private readonly IDocumentGetUseCase _documentGetUseCase;
        public DocumentController(
            IDocumentCreateUseCase documentCreateUseCase,
            IDocumentGetUseCase documentGetUseCase,
            IMapper mapper)
        {
            _documentCreateUseCase = documentCreateUseCase;
            _documentGetUseCase = documentGetUseCase;

            _mapper = mapper;
        }

        [HttpGet("GetByDate/{date}")]
        [EnableQuery(MaxExpansionDepth = 10)]
        public async Task<IQueryable<Document>> GetByDate( DateOnly date)
        {
            return _documentGetUseCase.GetByDocumentDate(date);
        }

        [HttpGet("GetByNo/{no}")]
        public async Task<Document> GetByNo(string no)
        {
            return  _documentGetUseCase.GetByDocumentNo(no);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] DocumentCreateBindingModel bindingModel, CancellationToken cancellationToken)
        {
            var output = await _documentCreateUseCase.AddDocument(_mapper.Map<DocumentCreateInputModel>(bindingModel), cancellationToken);

            if (output.IsSuccess)
                return Ok(_mapper.Map<DocumentCreateViewModel>(output.OutputModelFields));
            return Ok(output.Message);
        }
    }
}
