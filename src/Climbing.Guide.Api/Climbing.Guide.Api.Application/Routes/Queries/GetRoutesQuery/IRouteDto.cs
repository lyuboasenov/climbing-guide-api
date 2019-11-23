using Climbing.Guide.Api.Application.Routes.Entities;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   public interface IRouteDto {
      string AreaId { get; set; }
      float Difficulty { get; set; }
      string Id { get; set; }
      string Name { get; set; }
      RouteType RouteType { get; set; }
      string Schema { get; set; }
   }
}