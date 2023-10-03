using ChallengeMVFactory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Domain
{
    public class Country : BaseModel
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public ICollection<City>? Citys { get; set; }
    }
}
