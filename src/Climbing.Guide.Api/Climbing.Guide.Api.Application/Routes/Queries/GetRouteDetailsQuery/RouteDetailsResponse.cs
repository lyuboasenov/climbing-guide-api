using AutoMapper;
using Climbing.Guide.Api.Application.Mappings;
using System;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteDetailsQuery {
   public  class RouteDetailsResponse : IMapFrom<Domain.Entities.Route> {
      public string Id { get; set; }
      public DateTime CreatedOn { get; set; }
      public string CreatedById { get; set; }
      public string CreatedByName { get; set; }
      public DateTime UpdatedOn { get; set; }
      public string UpdatedById { get; set; }
      public string UpdatedByName { get; set; }
      public double Latitude { get; set; }
      public double Longitude { get; set; }
      public string AreaId { get; set; }
      public string AreaName { get; set; }
      public float Difficulty { get; set; }
      public float Rating { get; set; }
      public ushort Length { get; set; }
      public string Name { get; set; }
      public string Info { get; set; }
      public string Approach { get; set; }
      public string History { get; set; }
      public Common.RouteType Type { get; set; }
      public IEnumerable<Point> Topo { get; internal set; }
      public string Schema { get; set; }

      public void Mapping(Profile profile) {
         profile.CreateMap<Domain.Entities.Route, RouteDetailsResponse>()
             .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
      }

      public class Point {
         public double X { get; set; }
         public double Y { get; set; }
      }
   }
}