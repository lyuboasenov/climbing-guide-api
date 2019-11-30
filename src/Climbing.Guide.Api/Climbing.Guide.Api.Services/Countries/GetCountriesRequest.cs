using Climbing.Guide.Api.Application.Countries.Queries.GetCountriesQuery;
using Climbing.Guide.Api.Common.Mappings;

namespace Climbing.Guide.Api.Services.Countries {
   public partial class GetCountriesRequest : IGetCountriesQueryRequest, IMapFrom<IGetCountriesQueryRequest> {
   }
}
