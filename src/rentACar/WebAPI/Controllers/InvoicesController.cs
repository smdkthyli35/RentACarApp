using Application.Features.Invoices.Commands.CreateInvoice;
using Application.Features.Invoices.Commands.DeleteInvoice;
using Application.Features.Invoices.Commands.UpdateInvoice;
using Application.Features.Invoices.Dtos;
using Application.Features.Invoices.Queries.GetInvoiceById;
using Application.Features.Invoices.Queries.GetInvoiceList;
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
    public class InvoicesController : BaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetInvoiceListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetInvoiceByIdQuery getInvoiceByIdQuery)
        {
            InvoiceDto result = await Mediator.Send(getInvoiceByIdQuery);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateInvoiceCommand createInvoiceCommand)
        {
            var result = await Mediator.Send(createInvoiceCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteInvoiceCommand deleteInvoiceCommand)
        {
            var result = await Mediator.Send(deleteInvoiceCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateInvoiceCommand updateInvoiceCommand)
        {
            var result = await Mediator.Send(updateInvoiceCommand);
            return Created("", result);
        }
    }
}
