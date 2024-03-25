using HrLeaveManagement.Server.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HrLeaveManagement.Server.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HrLeaveManagement.Server.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HrLeaveManagement.Server.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HrLeaveManagement.Server.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HrLeaveManagement.Server.Features.LeaveRequest.Commands.ChangeLeaveRequest;
using HrLeaveManagement.Server.Features.LeaveRequest.Commands.CreateLeaveRequestCommand;
using HrLeaveManagement.Server.Features.LeaveRequest.Commands.DeleteLeaveRequestCommand;
using HrLeaveManagement.Server.Features.LeaveRequest.Commands.UpdateLeaveRequestCommand;
using HrLeaveManagement.Server.Features.LeaveRequest.Queries.GetLeave_RequestDetail;
using HrLeaveManagement.Server.Features.LeaveRequest.Queries.GetLeaveRequestList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : Controller
    {
        private readonly IMediator _mediator;
        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDTO>>> Get(bool isLoggedInUser = false)
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListQuery());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDetailsDTO>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailQuery { Id = id });
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateLeaveRequestCommand leaveRequest)
        {
            var response = await _mediator.Send(leaveRequest);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveRequestCommand leaveRequest)
        {
            await _mediator.Send(leaveRequest);
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<LeaveRequestsController>/CancelRequest
        [HttpPut]
        [Route("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelRequest(ChangeLeaveRequestApprovalCommand cancelLeaveRequest)
        {
            await _mediator.Send(cancelLeaveRequest);
            return NoContent();
        }

        // PUT api/<LeaveRequestsController>/UpdateApproval
        [HttpPut]
        [Route("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateRequest(ChangeLeaveRequestApprovalCommand cancelLeaveRequest)
        {
            await _mediator.Send(cancelLeaveRequest);
            return NoContent();
        }
    }
}
