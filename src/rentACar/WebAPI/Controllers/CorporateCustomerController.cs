﻿using Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;
using Application.Features.CorporateCustomers.Commands.DeleteCorporateCustomer;
using Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer;
using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Queries.GetCorporateCustomerById;
using Application.Features.CorporateCustomers.Queries.GetCorporateCustomerList;
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
    public class CorporateCustomerController : BaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCorporateCustomerListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCorporateCustomerByIdQuery getCorporateCustomerByIdQuery)
        {
            CorporateCustomerDto result = await Mediator.Send(getCorporateCustomerByIdQuery);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCorporateCustomerCommand createCorporateCustomerCommand)
        {
            var result = await Mediator.Send(createCorporateCustomerCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCorporateCustomerCommand deleteCorporateCustomerCommand)
        {
            var result = await Mediator.Send(deleteCorporateCustomerCommand);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand updateCorporateCustomerCommand)
        {
            var result = await Mediator.Send(updateCorporateCustomerCommand);
            return Ok(result);
        }
    }
}
