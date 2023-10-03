using ChallengeMVFactory.Application.Contracts.Persistence;
using ChallengeMVFactory.Domain;
using ChallengeMVFactory.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Infrastructure.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(MVFactoryDbContext mvfactoryDbContext) : base(mvfactoryDbContext)
        {
        }
    }
}
