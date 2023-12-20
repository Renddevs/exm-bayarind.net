using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Newtonsoft.Json.Linq;
using Bayarind.Infrastructure.PaymentGateway.Object;
using Vleko.Bayarind.Core.PaymentGateway;

namespace Vleko.Bayarind.API.Controllers
{
    public partial class PaymentGatewayController : BaseController<PaymentGatewayController>
    {
        [HttpPost(template: "sent_payment_flag")]
        public async Task<IActionResult> SentPaymentFlag([FromBody] PaymentFlagRequest request)
        {
            var add_request = _mapper.Map<SentPaymentFlagRequest>(request);
            return Wrapper(await _mediator.Send(add_request));
        }
    }
}

