using ChallengeMVFactory.Application.Models.ExternalApi.Weather;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.City.Commands.AddCity
{
    public class AddCityValidator : AbstractValidator<AddCityCommand>
    {
        public AddCityValidator() {
            RuleFor(x => x.CityName)
            .Must(IsValidSource);
            
                
          

        }

        private bool IsValidSource(string arg)
        {
            if(string.IsNullOrEmpty(arg)) return false;

            return true;
        }
    }
}
