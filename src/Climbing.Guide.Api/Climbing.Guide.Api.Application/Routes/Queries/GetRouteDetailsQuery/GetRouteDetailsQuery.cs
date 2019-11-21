using Climbing.Guide.Api.Application.Routes.Common;
using MediatR;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteDetailsQuery {
   public class GetRouteDetailsQuery : IRequest<RouteDetailsResponse> {
      public string Id { get; set; }
      public SchemaSize SchemaSize { get; set; }
   }
}
