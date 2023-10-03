using ChallengeMVFactory.Application.Contracts.ExternalApi;
using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Domain;
using ChallengeMVFactory.Infrastructure.External;
using ChallengeMVFactory.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Infrastructure.Persistence
{
    public class DataSeeder
    {
        private readonly MVFactoryDbContext _mvfactoryDbContext;
        ICountryExternalApi _icountryExternalApi;
        ICountryRepository _countryRepository;
        public DataSeeder(MVFactoryDbContext mvfactoryDbContext, ICountryExternalApi icountryExternalApi, ICountryRepository countryRepository)
        {
            _mvfactoryDbContext = mvfactoryDbContext;
            _icountryExternalApi = icountryExternalApi;
            _countryRepository = countryRepository;
        }

        public async Task Seed()
        {
            var exis = await _countryRepository.GetAllAsync();
            
            if (!exis.Any())
            {
                var Lista = await _icountryExternalApi.getCountry();

                var listaCountr = Lista.Select(a=> new Country { 
                  CountryName = a.CountryName,
                  CountryCode = a.CountryCode,
                }).ToList();

                foreach (var country in listaCountr)
                {
                 await   _countryRepository.AddAsync(country);
                }
            }
        }
    }
}
