using Climbing.Guide.Api.Application.Entities;
using Climbing.Guide.Api.Application.Routes.Entities;
using MediatR;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   public interface IGetRouteListQuery : IRequest<RouteListResponse>, IOffsetQuery {
      string Filter { get; }
      SchemaSize SchemaSize { get; set; }
   }
}
