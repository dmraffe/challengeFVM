using ChallengeMVFactory.Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Contracts.ExternalApi
{
    public interface ICountryExternalApi
    {
        Task<List<CountryResponse>> getCountry();
    }
}
