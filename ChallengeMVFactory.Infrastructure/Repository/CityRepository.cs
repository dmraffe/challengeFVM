using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Domain;
using ChallengeMVFactory.Infrastructure.Persistence;

namespace ChallengeMVFactory.Infrastructure.Repository
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(MVFactoryDbContext mvfactoryDbContext) : base(mvfactoryDbContext)
        {
        }
    }
}
