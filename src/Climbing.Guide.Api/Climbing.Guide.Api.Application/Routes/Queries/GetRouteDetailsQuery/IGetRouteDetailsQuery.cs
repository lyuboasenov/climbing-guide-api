using Climbing.Guide.Api.Application.Routes.Entities;
using MediatR;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteDetailsQuery {
   public interface IGetRouteDetailsQuery : IRequest<IRouteDetailsReply> {
      string Id { get; }
      SchemaSize SchemaSize { get; }
   }
}
