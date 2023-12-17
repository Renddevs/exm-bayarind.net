using Bayarind.Infrastructure.PaymentGateway.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vleko.Result;

namespace Bayarind.Infrastructure.PaymentGateway.Interface
{
    public interface IPaymentGatewayService
    {
        Task<ObjectResponse<TransactionResponse>> CreateTransaction(TransactionRequest request);
    }
}
