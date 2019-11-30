using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Areas.Queries.GetAreasQuery {
   internal class GetAreasQueryReply : IGetAreasQueryReply {
      public int Offset { get; set; }
      public int Count { get; set; }
      public bool HasMore { get; set; }
      public IEnumerable<IAreaDto> Results { get; set; }
   }
}
