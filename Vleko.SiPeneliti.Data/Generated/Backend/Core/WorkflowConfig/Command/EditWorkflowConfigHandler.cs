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

namespace Vleko.SiPeneliti.Core.WorkflowConfig.Command
{

    #region Request
    public class EditWorkflowConfigMapping: Profile
    {
        public EditWorkflowConfigMapping()
        {
            CreateMap<EditWorkflowConfigRequest, WorkflowConfigRequest>().ReverseMap();
        }
    }
    public class EditWorkflowConfigRequest :WorkflowConfigRequest, IMapRequest<Vleko.SiPeneliti.Data.Model.WorkflowConfig, EditWorkflowConfigRequest>,IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<EditWorkflowConfigRequest, Vleko.SiPeneliti.Data.Model.WorkflowConfig> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class EditWorkflowConfigHandler : IRequestHandler<EditWorkflowConfigRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public EditWorkflowConfigHandler(
            ILogger<EditWorkflowConfigHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(EditWorkflowConfigRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var existingItems = await _context.Entity<Vleko.SiPeneliti.Data.Model.WorkflowConfig>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
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
                    result.NotFound($"Id WorkflowConfig {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Edit WorkflowConfig", request);
                result.Error("Failed Edit WorkflowConfig", ex.Message);
            }
            return result;
        }
    }
}

