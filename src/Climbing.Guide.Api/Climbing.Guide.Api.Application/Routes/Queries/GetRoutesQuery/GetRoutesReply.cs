using Climbing.Guide.Api.Application.Entities;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   internal class GetRoutesReply : IOffsetReply, IGetRoutesReply {
      public int Offset { get; set; }
      public int Count { get; set; }
      public bool HasMore { get; set; }
      public string Filter { get; set; }
      public IEnumerable<IRouteDto> Results { get; set; }
   }
}