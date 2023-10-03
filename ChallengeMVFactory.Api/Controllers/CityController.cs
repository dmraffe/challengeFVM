using ChallengeMVFactory.Application.Features.City.Commands.AddCity;
using ChallengeMVFactory.Application.Features.City.Commands.Query;
using ChallengeMVFactory.Application.Features.HistoryWeather.Commands.AddHistory;
using ChallengeMVFactory.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChallengeMVFactory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private IMediator mediator;

        public CityController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost()]
        [Route("AddCity")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> AddCity([FromBody] AddCityCommand command)
        {

            var result = await this.mediator.Send(command);
            return Ok(result);

        }

        [HttpGet]
        [Route("GetCity")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetCity()
        {
            var command = new GetListCityQuery();
            var result = await this.mediator.Send(command);
            return Ok(result);

        }



    }
}
