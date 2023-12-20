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
using DocumentFormat.OpenXml.VariantTypes;
using System.Net.WebSockets;
using Vleko.Bayarind.Data.Model;
using Microsoft.Identity.Client;

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
    public class SentPaymentFlagRequest : PaymentFlagRequest, IRequest<ObjectResponse<PaymentFlagResponse>>
    {

    }
    #endregion

    internal class SentPaymentFlagHandler : IRequestHandler<SentPaymentFlagRequest, ObjectResponse<PaymentFlagResponse>>
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
                var data_transaction = await _context.Entity<TTransaction>().Where(d => d.Id == request.insertId).FirstOrDefaultAsync();
                var updateFlag = await _payment.SendPaymentFlag(request);
                if (!updateFlag.Succeeded) {
                    result.Error("Error sent payment flag", updateFlag.Message);
                    return result;
                }
                data_transaction.FlagType = updateFlag.Data.flagType;
                var update_flag_transaction = await _context.UpdateSave(data_transaction);
                if (!update_flag_transaction.Success) {
                    result.Error("Error update data transaction", update_flag_transaction.ex.Message);
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

