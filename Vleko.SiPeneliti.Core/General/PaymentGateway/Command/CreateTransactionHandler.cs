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
    public class CreateTransactionMapping
    {
        public CreateTransactionMapping()
        {
            //CreateMap<CreateTransactionRequest, TransactionRequest>().ReverseMap();
        }
    }
    public class CreateTransactionRequest : TransactionRequest, IRequest<StatusResponse>
    {

    }
    #endregion

    internal class CreateTransactionHandler : IRequestHandler<CreateTransactionRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IGeneralHelper _helper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IPaymentGatewayService _payment;
        public CreateTransactionHandler(
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
        public async Task<StatusResponse> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var create = await _payment.CreateTransaction(request);
                if (!create.Succeeded) {
                    result.Error("Error create transaction", create.Message);
                    return result;
                }
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Create Transaction", request);
                result.Error("Failed Create Transaction", ex.Message);
            }
            return result;
        }
    }
}

