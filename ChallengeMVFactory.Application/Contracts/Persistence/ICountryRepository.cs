using ChallengeMVFactory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Contracts.Persistence
{
    public interface ICountryRepository : IAsyncRepository<Country>
    {
    }
}
