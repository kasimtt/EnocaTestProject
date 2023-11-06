using EnocaTextProject.Application.Dtos.CarrierConfigurationDto;
using EnocaTextProject.Application.Feature.Commands.Carrier.CreateCarrier;
using EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.UpdateCarrierConfigurationWithCarrierId;
using EnocaTextProject.Application.Feature.Queries.CarrierConfiguration;
using EnocaTextProject.Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnocaTestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CarrierConfigurationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]/{Id}")]
        public async Task<IActionResult> CreateConfiguration([FromRoute] int Id, [FromBody] CreateCarrierConfigurationDto createCarrierConfigurationDto)
        {
            CreateCarrierConfigurationCommandResponse response =await _mediator.Send(new CreateCarrierConfigurationCommandRequest
            {
                CreateCarrierConfigurationDto = createCarrierConfigurationDto,
                Id = Id,

            });

            return Ok(response.Message);
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> DeleteConfiguration()
        {
            return Ok("configurasyonların silinmesi gereksiz. carrier silersin zaten silinir. ya eklersin ya güncellersin");
           
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateConfiguration([FromBody] UpdateCarrierConfigurationCommandRequest request)
        {
            UpdateCarrierConfigurationCommandResponse response = await _mediator.Send(request);
            if (response.Success)
            {
                return Ok(response.Message);
            }
            return NotFound(response.Message);
            
        }

        [HttpPut("[action]/{Id}")]

        public async Task<IActionResult> UpdateCarrierConfigurationWithCarrierId([FromRoute] int Id  , [FromBody] UpdateCarrierConfigurationWithCarrierIdDto dto)
        {
            UpdateCarrierConfigurationWithCarrierIdCommandResponse response =await _mediator.Send(new UpdateCarrierConfigurationWithCarrierIdCommandRequest
            {
                Id = Id,
                carrierConfiguration = dto
            });
            if(response.Success)
            {
                return Ok(response.Message);
            }
            return NotFound(response.Message);
           
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] Pagination Pagination)
        {
            GetAllCarrierConfigurationQueryResponse response = await _mediator.Send(new GetAllCarrierConfigurationQueryRequest
            {
                Pagination = Pagination
            });
            return Ok(response);
        }

    }
}
