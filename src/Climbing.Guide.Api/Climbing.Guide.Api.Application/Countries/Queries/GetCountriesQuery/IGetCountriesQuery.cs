using Climbing.Guide.Api.Application.Entities;
using MediatR;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountriesQuery {
   public interface IGetCountriesQuery : IRequest<IGetCountriesQueryReply>, IOffsetQuery {
   }
}
