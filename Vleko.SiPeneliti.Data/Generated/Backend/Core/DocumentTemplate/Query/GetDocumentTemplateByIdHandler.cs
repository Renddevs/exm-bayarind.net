//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Vleko.SiPeneliti.Data;
using Vleko.SiPeneliti.Data.Model;
using Vleko.Result;
using Vleko.SiPeneliti.Core.Response;

namespace Vleko.SiPeneliti.Core.DocumentTemplate.Query
{

    public class GetDocumentTemplateByIdRequest : IRequest<ObjectResponse<DocumentTemplateResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetDocumentTemplateByIdHandler : IRequestHandler<GetDocumentTemplateByIdRequest, ObjectResponse<DocumentTemplateResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetDocumentTemplateByIdHandler(
            ILogger<GetDocumentTemplateByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<DocumentTemplateResponse>> Handle(GetDocumentTemplateByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<DocumentTemplateResponse> result = new ObjectResponse<DocumentTemplateResponse>();
            try
            {
                var item = await _context.Entity<Vleko.SiPeneliti.Data.Model.DocumentTemplate>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<DocumentTemplateResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Vleko.SiPeneliti.Data.Model.DocumentTemplate {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail DocumentTemplate", request.Id);
                result.Error("Failed Get Detail DocumentTemplate", ex.Message);
            }
            return result;
        }
    }
}

