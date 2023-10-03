using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Domain;
using ChallengeMVFactory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChallengeMVFactory.Infrastructure.Repository
{
    public class HistoryWatherRepository : BaseRepository<HistoryWeatherCity>, IHistoryWatherRepository
    {
        private MVFactoryDbContext _mvfactoryDbContext;
        public HistoryWatherRepository(MVFactoryDbContext mvfactoryDbContext) : base(mvfactoryDbContext)
        {

            _mvfactoryDbContext = mvfactoryDbContext;
        }

        public async Task<IReadOnlyList<HistoryWeatherCity>> GetWatherAsync(int Cityid)
        {
            var lis = await _mvfactoryDbContext.HistoryWeatherCitys.Include(a => a.City).Where(a=>a.CityId == Cityid).ToListAsync() ;
            return lis ;
        }
    }
}
