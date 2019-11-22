using Climbing.Guide.Api.Application.Entities;
using Climbing.Guide.Api.Application.Routes.Common;
using MediatR;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   public interface IGetRouteListQuery : IRequest<RouteListResponse>, IEnumerableOffsetQuery {
      string Filter { get; }
      SchemaSize SchemaSize { get; set; }
   }
}
