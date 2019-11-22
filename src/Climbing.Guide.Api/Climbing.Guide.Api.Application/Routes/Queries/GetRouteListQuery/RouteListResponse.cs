using Climbing.Guide.Api.Application.Entities;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   public class RouteListResponse : IEnumerableOffsetResponse<RouteListDto> {
      public int Offset { get; set; }
      public int Count { get; set; }
      public bool HasMore { get; set; }
      public string Filter { get; set; }
      public IEnumerable<RouteListDto> Result { get; internal set; }
   }
}