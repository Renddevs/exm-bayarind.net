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

namespace Vleko.SiPeneliti.Core.BidangPenelitian.Query
{

    public class GetBidangPenelitianByIdRequest : IRequest<ObjectResponse<BidangPenelitianResponse>>
    {
        [Required]
        public string Id { get; set; }
    }
    internal class GetBidangPenelitianByIdHandler : IRequestHandler<GetBidangPenelitianByIdRequest, ObjectResponse<BidangPenelitianResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetBidangPenelitianByIdHandler(
            ILogger<GetBidangPenelitianByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<BidangPenelitianResponse>> Handle(GetBidangPenelitianByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<BidangPenelitianResponse> result = new ObjectResponse<BidangPenelitianResponse>();
            try
            {
                var item = await _context.Entity<Vleko.SiPeneliti.Data.Model.BidangPenelitian>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<BidangPenelitianResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Vleko.SiPeneliti.Data.Model.BidangPenelitian {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail BidangPenelitian", request.Id);
                result.Error("Failed Get Detail BidangPenelitian", ex.Message);
            }
            return result;
        }
    }
}
