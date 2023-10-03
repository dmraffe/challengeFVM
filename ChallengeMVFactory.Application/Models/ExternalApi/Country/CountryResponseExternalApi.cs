using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Models.ExternalApi.Country
{





    public class CountryApi
    {
        public Name name { get; set; }
        public string cca2 { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }

    }






}
