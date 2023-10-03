using ChallengeMVFactory.Application.Models.ExternalApi.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Contracts.ExternalApi
{
    public interface IWeatherExternalApi
    {

        Task<WeatherAiResponse> GetWeatherAiResponse(string city, string country);

    }
}
