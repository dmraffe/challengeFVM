using ChallengeMVFactory.Application.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMVFactory.Application.Features.Country.Query
{
    public class GetListCountry : IRequest<List<ChallengeMVFactory.Domain.Country>>
    {
    }
}
