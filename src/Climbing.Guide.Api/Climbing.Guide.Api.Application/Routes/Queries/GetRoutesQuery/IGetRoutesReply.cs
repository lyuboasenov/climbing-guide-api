using Climbing.Guide.Api.Application.Entities;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   public interface IGetRoutesReply : IEnumerableReply<IRouteDto>, IOffsetReply<IRouteDto> {
      string Filter { get; set; }
   }
}