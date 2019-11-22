using System.Collections.Generic;
using Climbing.Guide.Api.Application.Entities;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountryListQuery {
   internal class GetCountryListQueryResponse : IEnumerableOffsetResponse<ICountryListDto>, IGetCountryListQueryResponse {
      public int Offset { get; set; }
      public int Count { get; set; }
      public bool HasMore { get; set; }
      public IEnumerable<ICountryListDto> Result { get; set; }
   }
}