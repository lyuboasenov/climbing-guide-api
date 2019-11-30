using Climbing.Guide.Api.Application.Entities;
using MediatR;

namespace Climbing.Guide.Api.Application.Areas.Queries.GetAreasQuery {
   public interface IGetAreasQueryRequest : IRequest<IGetAreasQueryReply>, IOffsetQuery {

   }
}
