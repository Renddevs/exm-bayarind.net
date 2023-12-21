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
    public class CreateTransactionRequest : CTransactionRequest, IRequest<ObjectResponse<string>>
    {

    }
    #endregion

    internal class CreateTransactionHandler : IRequestHandler<CreateTransactionRequest, ObjectResponse<string>>
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
        public async Task<ObjectResponse<string>> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<string> result = new ObjectResponse<string>();
            try
            {
                #region config
                var url = _configuration["bayarindConfig:url"];
                var secretKey = _configuration["bayarindConfig:secretKey"];
                #endregion

                var authCode = ComputeSha256Hash(request.transactionNo.ToString()+request.transactionAmount.ToString()+request.channelId+secretKey);
                var customerAccount = request.bankId + request.customerPhone.Substring(3);

                var data_transaction = new TTransaction()
                {
                    Id = 0,
                    ChannelId = request.channelId,
                    ServiceCode = request.serviceCode,
                    Currency = request.currency,
                    TransactionNo = request.transactionNo,
                    TransactionAmmoun = request.transactionAmount,
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
                    transactionAmount = request.transactionAmount,
                    transactionDate = request.transactionDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    transactionExpire = request.transactionExpire.ToString("yyyy-MM-dd HH:mm:ss"),
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
                result.Data = customerAccount;
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

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}

