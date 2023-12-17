//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vleko.SiPeneliti.Data;
using Vleko.Result;
using Vleko.SiPeneliti.Core.Helper;
using Vleko.SiPeneliti.Core.Request;

namespace Vleko.SiPeneliti.Core.WorkflowConfigDetail.Command
{

    #region Request
    public class EditWorkflowConfigDetailMapping: Profile
    {
        public EditWorkflowConfigDetailMapping()
        {
            CreateMap<EditWorkflowConfigDetailRequest, WorkflowConfigDetailRequest>().ReverseMap();
        }
    }
    public class EditWorkflowConfigDetailRequest :WorkflowConfigDetailRequest, IMapRequest<Vleko.SiPeneliti.Data.Model.WorkflowConfigDetail, EditWorkflowConfigDetailRequest>,IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<EditWorkflowConfigDetailRequest, Vleko.SiPeneliti.Data.Model.WorkflowConfigDetail> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class EditWorkflowConfigDetailHandler : IRequestHandler<EditWorkflowConfigDetailRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public EditWorkflowConfigDetailHandler(
            ILogger<EditWorkflowConfigDetailHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(EditWorkflowConfigDetailRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var existingItems = await _context.Entity<Vleko.SiPeneliti.Data.Model.WorkflowConfigDetail>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (existingItems != null)
                {
                    var item = _mapper.Map(request, existingItems);
                    item.UpdateBy = request.Inputer;
                    item.UpdateDate = DateTime.Now;
                    var update = await _context.UpdateSave(item);
                    if (update.Success)
                        result.OK();
                    else
                        result.BadRequest(update.Message);

                    return result;
                }
                else
                    result.NotFound($"Id WorkflowConfigDetail {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Edit WorkflowConfigDetail", request);
                result.Error("Failed Edit WorkflowConfigDetail", ex.Message);
            }
            return result;
        }
    }
}
