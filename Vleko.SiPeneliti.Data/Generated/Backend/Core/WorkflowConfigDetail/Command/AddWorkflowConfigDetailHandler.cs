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

namespace Vleko.SiPeneliti.Core.WorkflowConfigDetail.Command
{

    #region Request
    public class AddWorkflowConfigDetailMapping: Profile
    {
        public AddWorkflowConfigDetailMapping()
        {
            CreateMap<AddWorkflowConfigDetailRequest, WorkflowConfigDetailRequest>().ReverseMap();
        }
    }
    public class AddWorkflowConfigDetailRequest :WorkflowConfigDetailRequest, IMapRequest<Vleko.SiPeneliti.Data.Model.WorkflowConfigDetail, AddWorkflowConfigDetailRequest>,IRequest<StatusResponse>
    {
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<AddWorkflowConfigDetailRequest, Vleko.SiPeneliti.Data.Model.WorkflowConfigDetail> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddWorkflowConfigDetailHandler : IRequestHandler<AddWorkflowConfigDetailRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddWorkflowConfigDetailHandler(
            ILogger<AddWorkflowConfigDetailHandler> logger,
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
        public async Task<StatusResponse> Handle(AddWorkflowConfigDetailRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Vleko.SiPeneliti.Data.Model.WorkflowConfigDetail>(request);
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
                _logger.LogError(ex, "Failed Add WorkflowConfigDetail", request);
                result.Error("Failed Add WorkflowConfigDetail", ex.Message);
            }
            return result;
        }
    }
}

