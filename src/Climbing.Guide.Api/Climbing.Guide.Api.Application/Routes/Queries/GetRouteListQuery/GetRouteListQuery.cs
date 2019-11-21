using Climbing.Guide.Api.Application.Routes.Common;
using MediatR;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   public class GetRouteListQuery : IRequest<RouteListResponse> {
      public string Filter { get; set; }
      public int Offset { get; set; }
      public int Count { get; set; }
      public SchemaSize SchemaSize { get; set; }
   }
}
