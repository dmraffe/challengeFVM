using ChallengeMVFactory.Application.Contracts.ExternalApi;
using ChallengeMVFactory.Application.Models;
using ChallengeMVFactory.Application.Models.ExternalApi.Country;
using ChallengeMVFactory.Application.Models.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Infrastructure.External
{
    public class CountryExternalApi : ICountryExternalApi
    {

        private readonly string url;
        public CountryExternalApi(IOptions<AppSetting> settings) {
            url = settings.Value.UrlServicesCountry;
        }
        public async Task<List<CountryResponse>> getCountry()
        {
            HttpClient client = new HttpClient();
           
            HttpResponseMessage response = await client.GetAsync(url);

            var respues = await response.Content.ReadAsStringAsync();

             var lista = JsonConvert.DeserializeObject<List<CountryApi>>(respues);
             
            return lista.OrderBy(a => a.name.common).Select(a => new CountryResponse { 
                 CountryName = a.name.common,
                 CountryCode = a.cca2

            }  ).ToList();
            
        }
    }
}
