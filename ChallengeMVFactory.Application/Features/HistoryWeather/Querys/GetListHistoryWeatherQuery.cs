using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.HistoryWeather.Querys
{
    public class GetListHistoryWeatherQuery :  IRequest<List<ChallengeMVFactory.Domain.HistoryWeatherCity>>
    {
        public int CityID { get; private set; }

        public GetListHistoryWeatherQuery(int cityID)
        {
            CityID = cityID;
        }
    }
}
