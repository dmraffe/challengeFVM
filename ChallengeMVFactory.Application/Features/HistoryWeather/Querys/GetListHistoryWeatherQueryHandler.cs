using ChallengeMVFactory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.HistoryWeather.Querys
{
    public class GetListHistoryWeatherQueryHandler : IRequestHandler<GetListHistoryWeatherQuery, List<ChallengeMVFactory.Domain.HistoryWeatherCity>>
    {
        public Task<List<HistoryWeatherCity>> Handle(GetListHistoryWeatherQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
