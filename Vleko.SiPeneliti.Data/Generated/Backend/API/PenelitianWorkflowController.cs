//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Vleko.SiPeneliti.Core.PenelitianWorkflow.Query;
using Vleko.SiPeneliti.Core.Request;
using Vleko.SiPeneliti.Core.PenelitianWorkflow.Command;

namespace Vleko.SiPeneliti.API.Controllers
{
    public partial class PenelitianWorkflowController : BaseController<PenelitianWorkflowController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Wrapper(await _mediator.Send(new GetPenelitianWorkflowByIdRequest() { Id = id }));
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetPenelitianWorkflowListRequest>(request);
            return Wrapper(await _mediator.Send(list_request));
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] PenelitianWorkflowRequest request)
        {
            var add_request = _mapper.Map<AddPenelitianWorkflowRequest>(request);
            add_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(add_request));
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] PenelitianWorkflowRequest request)
        {
            var edit_request = _mapper.Map<EditPenelitianWorkflowRequest>(request);
            edit_request.Id = id;
            edit_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(edit_request));
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeletePenelitianWorkflowRequest() { Id = id, Inputer = Inputer }));
        }

        
    }
}
