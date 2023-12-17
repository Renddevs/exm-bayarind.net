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
using Microsoft.EntityFrameworkCore;
using Vleko.SiPeneliti.Data;
using Vleko.Result;

namespace Vleko.SiPeneliti.Core.User.Command
{

    #region Request
    public class DeleteUserRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Inputer { get; set; }
    }
    #endregion

    internal class DeleteUserHandler : IRequestHandler<DeleteUserRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DeleteUserHandler(
            ILogger<DeleteUserHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Vleko.SiPeneliti.Data.Model.User>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    var delete = await _context.DeleteSave(item);
                    if (delete.Success)
                        result.OK();
                    else
                        result.BadRequest(delete.Message);

                    return result;
                }
                else
                    result.NotFound($"Id User {request.Id} Tidak Ditemukan");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Delete User", request.Id);
                result.Error("Failed Delete User", ex.Message);
            }
            return result;
        }
    }
}

