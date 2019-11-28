using System.Collections.Generic;
using Climbing.Guide.Api.Application.Entities;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountriesQuery {
   internal class GetCountriesQueryReply : IOffsetReply, IGetCountriesQueryReply {
      public int Offset { get; set; }
      public int Count { get; set; }
      public bool HasMore { get; set; }
      public IEnumerable<ICountryDto> Results { get; set; }
   }
}