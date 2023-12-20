using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Vleko.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vleko.Bayarind.Core.Helper;
using Vleko.Bayarind.Data;
using Bayarind.Infrastructure.PaymentGateway.Object;
using Bayarind.Infrastructure.PaymentGateway.Interface;
using Bayarind.Infrastructure.PaymentGateway.Service;

namespace Vleko.Bayarind.Core.PaymentGateway
{
    #region Request
    public class SentPaymentFlagMapping
    {
        public SentPaymentFlagMapping()
        {
            //CreateMap<SentPaymentFlagRequest, TransactionRequest>().ReverseMap();
        }
    }
    public class SentPaymentFlagRequest : PaymentFlagRequest, IRequest<StatusResponse>
    {

    }
    #endregion

    internal class SentPaymentFlagHandler : IRequestHandler<SentPaymentFlagRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IGeneralHelper _helper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IPaymentGatewayService _payment;
        public SentPaymentFlagHandler(
            IMediator mediator,
            IGeneralHelper helper,
            IUnitOfWork<ApplicationDBContext> context,
            IPaymentGatewayService payment
            )
        {
            _mediator = mediator;
            _helper = helper;
            _context = context;
            _payment = payment;
        }
        public async Task<ObjectResponse<PaymentFlagResponse>> Handle(SentPaymentFlagRequest request, CancellationToken cancellationToken)
        {
            var result = new ObjectResponse<PaymentFlagResponse>();
            try
            {
                var create = await _payment.SendPaymentFlag(request);
                if (!create.Succeeded) {
                    result.Error("Error sent payment flag", create.Message);
                    return result;
                }
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed sent payment flag", request);
                result.Error("Failed sent payment flag", ex.Message);
            }
            return result;
        }
    }
}

