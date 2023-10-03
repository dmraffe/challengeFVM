using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Domain;
using ChallengeMVFactory.Infrastructure.Persistence;

namespace ChallengeMVFactory.Infrastructure.Repository
{
    public class HistoryWatherRepository : BaseRepository<HistoryWeatherCity>, IHistoryWatherRepository
    {
        public HistoryWatherRepository(MVFactoryDbContext mvfactoryDbContext) : base(mvfactoryDbContext)
        {
        }
    }
}
