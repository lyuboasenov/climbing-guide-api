using Climbing.Guide.Api.Application.Entities;
using MediatR;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountryListQuery {
   public interface IGetCountryListQuery : IRequest<IGetCountryListQueryResponse>, IEnumerableOffsetQuery {
   }
}
