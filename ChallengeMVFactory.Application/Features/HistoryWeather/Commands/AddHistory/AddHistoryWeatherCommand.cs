using ChallengeMVFactory.Application.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.HistoryWeather.Commands.AddHistory
{
    public class AddHistoryWeatherCommand : IRequest<Response>
    {
       

        public bool SaveHistory { get; set; } = false;

        public int cityId { get; set; }
    }
}
