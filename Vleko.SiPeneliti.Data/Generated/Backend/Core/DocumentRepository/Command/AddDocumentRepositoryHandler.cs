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

namespace Vleko.SiPeneliti.Core.DocumentRepository.Command
{

    #region Request
    public class AddDocumentRepositoryMapping: Profile
    {
        public AddDocumentRepositoryMapping()
        {
            CreateMap<AddDocumentRepositoryRequest, DocumentRepositoryRequest>().ReverseMap();
        }
    }
    public class AddDocumentRepositoryRequest :DocumentRepositoryRequest, IMapRequest<Vleko.SiPeneliti.Data.Model.DocumentRepository, AddDocumentRepositoryRequest>,IRequest<StatusResponse>
    {
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<AddDocumentRepositoryRequest, Vleko.SiPeneliti.Data.Model.DocumentRepository> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddDocumentRepositoryHandler : IRequestHandler<AddDocumentRepositoryRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddDocumentRepositoryHandler(
            ILogger<AddDocumentRepositoryHandler> logger,
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
        public async Task<StatusResponse> Handle(AddDocumentRepositoryRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Vleko.SiPeneliti.Data.Model.DocumentRepository>(request);
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
                _logger.LogError(ex, "Failed Add DocumentRepository", request);
                result.Error("Failed Add DocumentRepository", ex.Message);
            }
            return result;
        }
    }
}

