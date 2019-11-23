using System;
using System.Collections.Generic;
using Climbing.Guide.Api.Application.Routes.Entities;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteDetailsQuery {
   public interface IRouteDetailsReply {
      string Approach { get; set; }
      string AreaId { get; set; }
      string AreaName { get; set; }
      string CreatedById { get; set; }
      string CreatedByName { get; set; }
      DateTime CreatedOn { get; set; }
      float Difficulty { get; set; }
      string History { get; set; }
      string Id { get; set; }
      string Info { get; set; }
      double Latitude { get; set; }
      ushort Length { get; set; }
      double Longitude { get; set; }
      string Name { get; set; }
      float Rating { get; set; }
      string Schema { get; set; }
      IEnumerable<SchemaPoint> Topo { get; }
      RouteType Type { get; set; }
      string UpdatedById { get; set; }
      string UpdatedByName { get; set; }
      DateTime UpdatedOn { get; set; }
   }
}