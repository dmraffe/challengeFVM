using ChallengeMVFactory.Application.Contracts.ExternalApi;
using ChallengeMVFactory.Application.Models;
using ChallengeMVFactory.Application.Models.ExternalApi.Country;
using ChallengeMVFactory.Application.Models.ExternalApi.Weather;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Infrastructure.External
{
    public class WeatherExternalApi : IWeatherExternalApi
    {

        private readonly string url;
        private readonly string key;
        public WeatherExternalApi(IOptions<AppSetting> settings)
        {
            url = settings.Value.UrlServicesWeather;
            key = settings.Value.ApiKeyServicesWeather;
        }
        public async Task<WeatherAiResponse> GetWeatherAiResponse(string city,string country)
        {
            HttpClient client = new HttpClient();
            string uri = $"{url}?q={city},{country}&APPID={key}";
            HttpResponseMessage response = await client.GetAsync(uri);

            var respues = await response.Content.ReadAsStringAsync();

            var WeatherAiResponse = JsonConvert.DeserializeObject<WeatherAiResponse>(respues);

            return WeatherAiResponse;
        }
    }
}
