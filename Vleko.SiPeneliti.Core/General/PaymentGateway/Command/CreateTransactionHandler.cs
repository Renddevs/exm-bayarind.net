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
using Vleko.Bayarind.Data.Model;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Cryptography;

namespace Vleko.Bayarind.Core.PaymentGateway
{
    #region Request
    public class CreateTransactionMapping
    {
        public CreateTransactionMapping()
        {
            //CreateMap<CreateTransactionRequest, CTransactionRequest>().ReverseMap();
        }
    }
    public class CreateTransactionRequest : CTransactionRequest, IRequest<StatusResponse>
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
        private readonly IConfiguration _configuration;
        public CreateTransactionHandler(
            IMediator mediator,
            IGeneralHelper helper,
            IUnitOfWork<ApplicationDBContext> context,
            IPaymentGatewayService payment,
            IConfiguration configuration
            )
        {
            _mediator = mediator;
            _helper = helper;
            _context = context;
            _payment = payment;
            _configuration = configuration;
        }
        public async Task<StatusResponse> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                #region config
                var url = _configuration["bayarindConfig:url"];
                var secretKey = _configuration["bayarindConfg:secretKey"];
                #endregion

                var authCode = QuickHash(1+request.transactionAmmount+request.channelId+secretKey);
                var customerAccount = request.bankId + request.customerPhone.Substring(3);

                var data_transaction = new TTransaction()
                {
                    Id = 0,
                    ChannelId = request.channelId,
                    ServiceCode = request.serviceCode,
                    Currency = request.currency,
                    TransactionNo = request.transactionNo,
                    TransactionAmmoun = request.transactionAmmount,
                    TransactionDate = request.transactionDate,
                    TransactionExpire = request.transactionExpire,
                    Description = request.description,
                    CallbackUrl = request.callbackURL,
                    CustomerAccount = customerAccount,
                    CustomerName = request.customerName,
                    AuthCode = authCode,
                    ProcessFds = 0,
                    TransactionStatus = null,
                    TransactionMessage = null,
                    FlagType = "00",
                };

                #region create transaction request
                var createTransRequest = new TransactionRequest()
                {
                    channelId = request.channelId,
                    serviceCode = request.serviceCode,
                    currency = request.currency,
                    transactionNo = request.transactionNo,
                    transactionAmount = request.transactionAmmount,
                    transactionDate = request.transactionDate,
                    transactionExpire = request.transactionExpire,
                    description = request.description,
                    callbackURL = request.callbackURL,
                    customerAccount = customerAccount,
                    customerName = request.customerName,
                    customerEmail = request.customerEmail,
                    customerPhone = request.customerPhone,
                    customerBillAddress = request.customerAddress,
                    authCode = authCode,
                };
                #endregion

                var create = await _payment.CreateTransaction(createTransRequest, url);
                if (!create.Succeeded) {
                    result.Error("Error create transaction", create.Message);
                    return result;
                }

                if (create.Data.insertStatus != "00") {
                    result.Error("Error create transaction", create.Data.insertMessage);
                    return result;
                }

                data_transaction.Id = Int32.Parse(create.Data.insertId);
                data_transaction.TransactionStatus = create.Data.insertStatus;
                data_transaction.TransactionMessage = create.Data.insertMessage;

                var insertTransaction = await _context.AddSave(data_transaction);
                if (!insertTransaction.Success) {
                    result.Error("Error save data transaction", insertTransaction.ex.Message);
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

        string QuickHash(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }
    }
}

