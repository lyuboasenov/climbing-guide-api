using Climbing.Guide.Api.Application.Entities;

namespace Climbing.Guide.Api.Application.Areas.Queries.GetAreasQuery {
   public interface IGetAreasQueryReply : IOffsetReply, IEnumerableReply<IAreaDto> {
   }
}
