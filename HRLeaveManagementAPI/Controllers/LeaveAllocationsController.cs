﻿using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRLeaveManagementApplication.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HRLeaveManagementApplication.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HRLeaveManagementApplication.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HRLeaveManagementApplication.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HRLeaveManagementApplication.Features.LeaveTypes.Commands.CreateLeaveType;
using HRLeaveManagementApplication.Features.LeaveTypes.Commands.DeleteLeaveType;
using HRLeaveManagementApplication.Features.LeaveTypes.Commands.UpdateLeaveType;
using HRLeaveManagementApplication.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HRLeaveManagementApplication.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : Controller
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> Get(bool isLoggedInUser = false)
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListQuery());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDetailsDTO>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailQuery { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateLeaveAllocationCommand leaveAllocation)
        {
            var response = await _mediator.Send(leaveAllocation);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveAllocationCommand leaveAllocation)
        {
            await _mediator.Send(leaveAllocation);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}