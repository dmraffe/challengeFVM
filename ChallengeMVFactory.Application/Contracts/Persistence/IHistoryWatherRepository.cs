using ChallengeMVFactory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Contracts.Persistence
{
    public interface IHistoryWatherRepository : IAsyncRepository<HistoryWeatherCity>
    {
        Task<IReadOnlyList<HistoryWeatherCity>> GetWatherAsync(int ID);
    }
}
