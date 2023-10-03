using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Application.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.City.Commands.Query
{
    public class GetListCityQuerysHandler : IRequestHandler<GetListCityQuery, Response>
    {
        ICityRepository _cityRepository;

        public GetListCityQuerysHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Response> Handle(GetListCityQuery request, CancellationToken cancellationToken)
        {
            
            var ls = await _cityRepository.GetAsync(a => a.CountryId != 0, null, "Country");
            return new Response(ls.ToList());
        }
    }
}
