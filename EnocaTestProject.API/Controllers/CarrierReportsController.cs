using EnocaTextProject.Application.Feature.Queries.CarrierReport.GetAllCarrierReport;
using EnocaTextProject.Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace EnocaTestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrierReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetAll([FromQuery]Pagination Pagination)
        {
            GetAllCarrierReportQueryResponse response = await _mediator.Send(new GetAllCarrierReportQueryRequest { Pagination = Pagination });
            return Ok(response);
        }

    }
}
