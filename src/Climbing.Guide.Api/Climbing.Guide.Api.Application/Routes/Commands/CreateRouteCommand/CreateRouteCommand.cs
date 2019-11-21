using MediatR;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Routes.Commands.CreateRouteCommand {
   public class CreateRouteCommand : IRequest<string> {
      public double Latitude { get; set; }
      public double Longitude { get; set; }
      public string AreaId { get; set; }
      public float Difficulty { get; set; }
      public float Rating { get; set; }
      public ushort Length { get; set; }
      public string Name { get; set; }
      public string Info { get; set; }
      public string Approach { get; set; }
      public string History { get; set; }
      public byte[] Schema { get; set; }

      public Common.RouteType Type { get; set; }
      public ICollection<Point> Topo { get; } = new HashSet<Point>();

      public class Point {
         public double X { get; set; }
         public double Y { get; set; }
      }
   }
}
