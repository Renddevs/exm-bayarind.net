using Bayarind.Infrastructure.HttpRequest.Interface;
using Bayarind.Infrastructure.PaymentGateway.Interface;
using Vleko.Result;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Bayarind.Infrastructure.HttpRequest.Object;
using Bayarind.Infrastructure.PaymentGateway.Object;

namespace Bayarind.Infrastructure.PaymentGateway.Service
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        private readonly IHttpRequest _request;
        //private readonly IConfiguration _configuration;

        public PaymentGatewayService(IHttpRequest request) {
            _request = request;
        }

        public async Task<ObjectResponse<TransactionResponse>> CreateTransaction(TransactionRequest request, string url)
        {
            var result = new ObjectResponse<TransactionResponse>();
            try
            {
                var (IsSuccess, ErrorMessage, Result, ex) = await _request.DoRequestData<TransactionResponse>(HttpMethod.Post, null, EnumHttpRequest.NoAuth, url, request);
                if (IsSuccess)
                {
                    result.Data = Result;
                    result.OK();
                }
                else
                {
                    result.BadRequest(ex.Message);
                }   
            }
            catch (Exception ex)
            {
                result.Error("Failed Create Transaction", ex.Message);
            }
            return result;
        }

        public async Task<ObjectResponse<PaymentFlagResponse>> SendPaymentFlag(PaymentFlagRequest request)
        {
            var result = new ObjectResponse<PaymentFlagResponse>();
            try
            {
                var url = "";
                var credentialApi = "";
                var (IsSuccess, ErrorMessage, Result, ex) = await _request.DoRequestData<PaymentFlagResponse>(HttpMethod.Post, credentialApi, EnumHttpRequest.API_Key, url, request);
                if (IsSuccess)
                {
                    result.Data = Result;
                    result.OK();
                }
                else
                {
                    result.BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                result.Error("Failed Send Payment Flag", ex.Message);
            }
            return result;
        }
    }
}
