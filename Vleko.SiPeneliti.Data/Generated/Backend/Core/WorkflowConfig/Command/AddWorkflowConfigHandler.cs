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
using Microsoft.Extensions.Logging;
using Vleko.SiPeneliti.Data;
using Vleko.Result;
using Vleko.SiPeneliti.Core.Helper;
using Vleko.SiPeneliti.Core.Request;

namespace Vleko.SiPeneliti.Core.WorkflowConfig.Command
{

    #region Request
    public class AddWorkflowConfigMapping: Profile
    {
        public AddWorkflowConfigMapping()
        {
            CreateMap<AddWorkflowConfigRequest, WorkflowConfigRequest>().ReverseMap();
        }
    }
    public class AddWorkflowConfigRequest :WorkflowConfigRequest, IMapRequest<Vleko.SiPeneliti.Data.Model.WorkflowConfig, AddWorkflowConfigRequest>,IRequest<StatusResponse>
    {
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<AddWorkflowConfigRequest, Vleko.SiPeneliti.Data.Model.WorkflowConfig> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddWorkflowConfigHandler : IRequestHandler<AddWorkflowConfigRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddWorkflowConfigHandler(
            ILogger<AddWorkflowConfigHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(AddWorkflowConfigRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Vleko.SiPeneliti.Data.Model.WorkflowConfig>(request);
                data.CreateBy = request.Inputer;
                data.CreateDate = DateTime.Now;
                var add = await _context.AddSave(data);
                if (add.Success)
                    result.OK();
                else
                    result.BadRequest(add.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add WorkflowConfig", request);
                result.Error("Failed Add WorkflowConfig", ex.Message);
            }
            return result;
        }
    }
}
