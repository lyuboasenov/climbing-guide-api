using Climbing.Guide.Api.Application.Entities;
using Climbing.Guide.Api.Application.Routes.Entities;
using MediatR;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   public interface IGetRoutesQuery : IRequest<IGetRoutesReply>, IOffsetQuery {
      string Filter { get; }
      SchemaSize SchemaSize { get; set; }
   }
}
