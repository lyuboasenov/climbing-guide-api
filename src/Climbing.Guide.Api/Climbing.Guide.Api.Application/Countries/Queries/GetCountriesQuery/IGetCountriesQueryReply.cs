using Climbing.Guide.Api.Application.Entities;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountriesQuery {
   public interface IGetCountriesQueryReply : IOffsetReply<ICountryDto>, IEnumerableReply<ICountryDto> {
   }
}