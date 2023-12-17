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

namespace Vleko.SiPeneliti.Core.Penelitian.Query
{

    public class GetPenelitianByIdRequest : IRequest<ObjectResponse<PenelitianResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetPenelitianByIdHandler : IRequestHandler<GetPenelitianByIdRequest, ObjectResponse<PenelitianResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetPenelitianByIdHandler(
            ILogger<GetPenelitianByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<PenelitianResponse>> Handle(GetPenelitianByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<PenelitianResponse> result = new ObjectResponse<PenelitianResponse>();
            try
            {
                var item = await _context.Entity<Vleko.SiPeneliti.Data.Model.Penelitian>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<PenelitianResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Vleko.SiPeneliti.Data.Model.Penelitian {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Penelitian", request.Id);
                result.Error("Failed Get Detail Penelitian", ex.Message);
            }
            return result;
        }
    }
}
