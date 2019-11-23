using MediatR;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Routes.Commands.CreateRouteCommand {
   public interface ICreateRouteCommand : IRequest<string> {
      public double Latitude { get; }
      public double Longitude { get; }
      public string AreaId { get; }
      public float Difficulty { get; }
      public float Rating { get; }
      public ushort Length { get; }
      public string Name { get; }
      public string Info { get; }
      public string Approach { get; }
      public string History { get; }
      public byte[] Schema { get; }

      public Entities.RouteType Type { get; }
      public IEnumerable<Entities.SchemaPoint> Topo { get; }
   }
}
