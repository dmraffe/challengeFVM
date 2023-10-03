using ChallengeMVFactory.Application.Models.Response;
using MediatR;
 
namespace ChallengeMVFactory.Application.Features.City.Commands.AddCity
{
    public class AddCityCommand : IRequest<Response>
    {
        public int CountryID { get; set; } 
        public string CityName { get; set; } 


    }
}
