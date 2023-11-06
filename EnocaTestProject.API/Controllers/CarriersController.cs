using AutoMapper;
using EnocaTextProject.Application.Feature.Commands.Carrier.CreateCarrier;
using EnocaTextProject.Application.Feature.Commands.Carrier.DeleteCarrier;
using EnocaTextProject.Application.Feature.Commands.Carrier.UpdateCarrier;
using EnocaTextProject.Application.Feature.Commands.Order.DeleteOrder;
using EnocaTextProject.Application.Feature.Queries.Carrier.GetAllCarrier;
using EnocaTextProject.Application.Feature.Queries.Carrier.GetByIdCarrier;
using EnocaTextProject.Application.Feature.Queries.Order.GetByIdOrder;
using EnocaTextProject.Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaTestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarriersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            GetAllCarrierQueryResponse response = await _mediator.Send(new GetAllCarrierQueryRequest { Pagination = pagination });
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCarrier([FromBody] CreateCarrierCommandRequest request)
        {
            CreateCarrierCommandResponse response = await _mediator.Send(request);
            if(response.Success)
            {
                return Ok($"{request.CarrierName} isimli kargo eklendi");
            }
             
            return BadRequest(response);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCarrier([FromBody] UpdateCarrierCommandRequest request)
        {
            UpdateCarrierCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            return NotFound(response.Message);
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> DeleteCarrier([FromRoute] DeleteCarrierCommandRequest request)
        {
            DeleteCarrierCommandResponse response = await _mediator.Send(request);
            if(response.Success )
            {
                return Ok(response.Message);
            }
            return NotFound(response.Message);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCarrierQueryRequest request)
        {
            GetByIdCarrierQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
