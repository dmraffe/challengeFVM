using ChallengeMVFactory.Application.Features.City.Commands.Query;
using ChallengeMVFactory.Application.Features.HistoryWeather.Commands.AddHistory;
using ChallengeMVFactory.Application.Features.HistoryWeather.Querys;
using ChallengeMVFactory.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChallengeMVFactory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private IMediator mediator;

        public WeatherController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        [Route("AddWeather")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> AddWeather([FromBody] AddHistoryWeatherCommand command)
        {

            var result = await this.mediator.Send(command);
            return Ok(result);

        }

        [HttpGet]
        [Route("GetWeather")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response>> GetWeather(int CityID)
        {
            var command = new GetListHistoryWeatherQuery(CityID);
            var result = await this.mediator.Send(command);
            return Ok(result);

        }

    }
}
