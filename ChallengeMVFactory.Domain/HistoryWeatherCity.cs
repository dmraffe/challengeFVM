using ChallengeMVFactory.Domain.Common;
 

namespace ChallengeMVFactory.Domain
{
    public class HistoryWeatherCity : BaseModel
    {
        public double Temperature { get; set; }
        public double ThermalSensation{ get; set; }
        public double TemperatureMin { get;set; }
        public double TemperatureMax { get; set; }
        public double Pressure { get; set; }

        public double Humidity { get; set; }

        public int CityId { get; set; }

        public virtual City? City { get; set; }
    }
}
