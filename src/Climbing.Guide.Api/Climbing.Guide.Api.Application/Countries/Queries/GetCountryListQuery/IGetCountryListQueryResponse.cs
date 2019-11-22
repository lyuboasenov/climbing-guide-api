using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountryListQuery {
   public interface IGetCountryListQueryResponse {
      int Count { get; }
      bool HasMore { get; }
      int Offset { get; }
      IEnumerable<ICountryListDto> Result { get; }
   }
}