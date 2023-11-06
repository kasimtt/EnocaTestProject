using EnocaTextProject.Application.Feature.Commands.Order.CreateOrder;
using EnocaTextProject.Application.Feature.Commands.Order.DeleteOrder;
using EnocaTextProject.Application.Feature.Queries.Order.GetAllOrder;
using EnocaTextProject.Application.Feature.Queries.Order.GetByIdOrder;
using EnocaTextProject.Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaTestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            GetAllOrderQueryResponse response =await _mediator.Send(new GetAllOrderQueryRequest { Pagination = pagination});
            return Ok(response);
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> DeleteAdvert([FromRoute] DeleteOrderCommandRequest request)
        {
            DeleteOrderCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return Ok("siparisiniz başarıyla silinmiştir");
            }
            return BadRequest();

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest request)
        {
            CreateOrderCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            return BadRequest();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOrderQueryRequest request)
        {
            GetByIdOrderQueryResponse response =await _mediator.Send(request);
            return Ok(response);
        }

    }
}
