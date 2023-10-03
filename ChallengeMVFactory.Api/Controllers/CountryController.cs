using ChallengeMVFactory.Application.Features.Country.Query;
using ChallengeMVFactory.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChallengeMVFactory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private IMediator mediator;

        public CountryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    

        [HttpGet]
        [Route("GetCountry")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CountryResponse>>> GetCountry()
        {
            var GetListCountryCommand = new GetListCountry();
            var result = await this.mediator.Send(GetListCountryCommand);
            return Ok(result);

        }




    }
}
