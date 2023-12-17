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

namespace Vleko.SiPeneliti.Core.Keperluan.Query
{

    public class GetKeperluanByIdRequest : IRequest<ObjectResponse<KeperluanResponse>>
    {
        [Required]
        public string Id { get; set; }
    }
    internal class GetKeperluanByIdHandler : IRequestHandler<GetKeperluanByIdRequest, ObjectResponse<KeperluanResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetKeperluanByIdHandler(
            ILogger<GetKeperluanByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<KeperluanResponse>> Handle(GetKeperluanByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<KeperluanResponse> result = new ObjectResponse<KeperluanResponse>();
            try
            {
                var item = await _context.Entity<Vleko.SiPeneliti.Data.Model.Keperluan>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<KeperluanResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Vleko.SiPeneliti.Data.Model.Keperluan {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Keperluan", request.Id);
                result.Error("Failed Get Detail Keperluan", ex.Message);
            }
            return result;
        }
    }
}

