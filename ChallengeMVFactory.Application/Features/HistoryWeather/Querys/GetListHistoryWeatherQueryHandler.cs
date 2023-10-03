using ChallengeMVFactory.Application.Contracts.ExternalApi;
using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.HistoryWeather.Querys
{
    public class GetListHistoryWeatherQueryHandler : IRequestHandler<GetListHistoryWeatherQuery, List<ChallengeMVFactory.Domain.HistoryWeatherCity>>
    {

     

        IHistoryWatherRepository _historyWatherRepository;

        

        public GetListHistoryWeatherQueryHandler( IHistoryWatherRepository historyWatherRepositor)
        {
            
            _historyWatherRepository = historyWatherRepositor;
            
        }
        public async Task<List<HistoryWeatherCity>> Handle(GetListHistoryWeatherQuery request, CancellationToken cancellationToken)
        {
             

           var list =   await _historyWatherRepository.GetWatherAsync(request.CityID);
            return list.ToList();
        }
    }
}
