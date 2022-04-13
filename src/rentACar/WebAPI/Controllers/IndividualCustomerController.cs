using Application.Features.InvidualCustomers.Commands.CreateInvidualCustomer;
using Application.Features.InvidualCustomers.Commands.DeleteInvidualCustomer;
using Application.Features.InvidualCustomers.Commands.UpdateInvidualCustomer;
using Application.Features.InvidualCustomers.Queries.GetInvidualCustomerList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomerController : BaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetInvidualCustomerListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateInvidualCustomerCommand createInvidualCustomerCommand)
        {
            var result = await Mediator.Send(createInvidualCustomerCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteInvidualCustomerCommand deleteInvidualCustomerCommand)
        {
            var result = await Mediator.Send(deleteInvidualCustomerCommand);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateInvidualCustomerCommand updateInvidualCustomerCommand)
        {
            var result = await Mediator.Send(updateInvidualCustomerCommand);
            return Ok(result);
        }
    }
}
