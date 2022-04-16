using Application.Features.CarDamages.Commands.CreateCarDamage;
using Application.Features.CarDamages.Commands.DeleteCarDamage;
using Application.Features.CarDamages.Commands.UpdateCarDamage;
using Application.Features.CarDamages.Queries.GetCarDamageList;
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
    public class CarDamagesController : BaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarDamageListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCarDamageCommand createCarDamageCommand)
        {
            var result = await Mediator.Send(createCarDamageCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCarDamageCommand deleteCarDamageCommand)
        {
            var result = await Mediator.Send(deleteCarDamageCommand);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCarDamageCommand updateCarDamageCommand)
        {
            var result = await Mediator.Send(updateCarDamageCommand);
            return Ok(result);
        }
    }
}
