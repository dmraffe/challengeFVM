using ChallengeMVFactory.Application.Contracts.ExternalApi;
using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Application.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.HistoryWeather.Commands.AddHistory
{
    public class AddHistoryWeatherCommandHandler : IRequestHandler<AddHistoryWeatherCommand, Response>
    {

        IWeatherExternalApi _weatherExternalApi;

        IHistoryWatherRepository _historyWatherRepository;

        ICityRepository _cityRepository;

        public AddHistoryWeatherCommandHandler(IWeatherExternalApi weatherExternalApi, IHistoryWatherRepository historyWatherRepositor, ICityRepository cityRepository)
        {
            _weatherExternalApi = weatherExternalApi;
            _historyWatherRepository = historyWatherRepositor;
            _cityRepository = cityRepository;
        }

        public async Task<Response> Handle(AddHistoryWeatherCommand request, CancellationToken cancellationToken)
        {

            var city = await _cityRepository.GetAsync(a=>a.Id ==request.cityId, null, "Country");

            var citySelect = city.FirstOrDefault();

            var ret =   await  _weatherExternalApi.GetWeatherAiResponse( citySelect.CityName, citySelect.Country.CountryCode);
            
            if(ret.main == null)
                return new Response(new Exception("nOT foUND"));
            if (request.SaveHistory )
            {
               await _historyWatherRepository.AddAsync(new Domain.HistoryWeatherCity
                {

                    CiyId = request.cityId,
                    Humidity = ret.main.humidity,
                    Pressure = ret.main.pressure,
                    Temperature = ret.main.temp,
                    TemperatureMax = ret.main.temp_max,
                    TemperatureMin = ret.main.temp_min,

                });
            } 


            return new Response(ret);
        }
    }
}
