using ChallengeMVFactory.Application.Contracts.ExternalApi;
using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Application.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.Country.Query
{
    public class GetListCountryQueryHandler : IRequestHandler<GetListCountry, List<ChallengeMVFactory.Domain.Country>>
    {

        ICountryRepository _countryRepository;

        public GetListCountryQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<ChallengeMVFactory.Domain.Country>> Handle(GetListCountry request, CancellationToken cancellationToken)
        {
            var lista = await _countryRepository.GetAllAsync();
            return lista.ToList();
           
        }
    }
}
