using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Application.Models.Response;
using ChallengeMVFactory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.City.Commands.AddCity
{

   

    public class AddCityCommandHandle : IRequestHandler<AddCityCommand, Response>
    {
        ICityRepository _cityRepository;

        public AddCityCommandHandle(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Response> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            await _cityRepository.AddAsync(new Domain.City
            {
                   CityName = request.CityName,
                   CountryId = request.CountryID,
            });
            var ls = await _cityRepository.GetAsync(a => a.CountryId != 0, null, "Country");
              return   new Response(ls.ToList());
        }
    }
}
