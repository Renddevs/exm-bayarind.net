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

namespace Vleko.SiPeneliti.Core.PenelitianWorkflowDetail.Query
{

    public class GetPenelitianWorkflowDetailByIdRequest : IRequest<ObjectResponse<PenelitianWorkflowDetailResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetPenelitianWorkflowDetailByIdHandler : IRequestHandler<GetPenelitianWorkflowDetailByIdRequest, ObjectResponse<PenelitianWorkflowDetailResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetPenelitianWorkflowDetailByIdHandler(
            ILogger<GetPenelitianWorkflowDetailByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<PenelitianWorkflowDetailResponse>> Handle(GetPenelitianWorkflowDetailByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<PenelitianWorkflowDetailResponse> result = new ObjectResponse<PenelitianWorkflowDetailResponse>();
            try
            {
                var item = await _context.Entity<Vleko.SiPeneliti.Data.Model.PenelitianWorkflowDetail>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<PenelitianWorkflowDetailResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Vleko.SiPeneliti.Data.Model.PenelitianWorkflowDetail {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail PenelitianWorkflowDetail", request.Id);
                result.Error("Failed Get Detail PenelitianWorkflowDetail", ex.Message);
            }
            return result;
        }
    }
}

