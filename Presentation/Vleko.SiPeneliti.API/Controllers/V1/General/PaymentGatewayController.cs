using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Newtonsoft.Json.Linq;
using Bayarind.Infrastructure.PaymentGateway.Object;
using Vleko.Bayarind.Core.PaymentGateway;
using Microsoft.AspNetCore.Authorization;

namespace Vleko.Bayarind.API.Controllers
{
    public partial class PaymentGatewayController : BaseController<PaymentGatewayController>
    {
        [AllowAnonymous]
        [HttpPost(template: "sent_payment_flag")]
        public async Task<IActionResult> SentPaymentFlag([FromBody] PaymentFlagRequest request)
        {
            var add_request = _mapper.Map<SentPaymentFlagRequest>(request);
            return Wrapper(await _mediator.Send(add_request));
        }

        [AllowAnonymous]
        [HttpPost(template: "create_transaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionRequest request)
        {
            var add_request = _mapper.Map<CreateTransactionRequest>(request);
            return Wrapper(await _mediator.Send(add_request));
        }
    }
}

