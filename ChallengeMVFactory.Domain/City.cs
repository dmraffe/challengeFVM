using ChallengeMVFactory.Domain.Common;
 

namespace ChallengeMVFactory.Domain
{
    public  class City : BaseModel
    {
 
 
         public string CityName { get; set; } = string.Empty;

        public int CountryId { get; set; }

        public virtual Country? Country { get; set; }

        public ICollection<HistoryWeatherCity>? History { get; set; }
    }
}
