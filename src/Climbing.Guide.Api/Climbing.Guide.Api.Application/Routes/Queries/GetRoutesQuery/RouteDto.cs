using AutoMapper;
using Climbing.Guide.Api.Application.Mappings;
using Climbing.Guide.Api.Application.Routes.Entities;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   internal class RouteDto : IMapFrom<Domain.Entities.Route>, IRouteDto {
      public string Id { get; set; }
      public string AreaId { get; set; }
      public string Name { get; set; }
      public string Schema { get; set; }
      public float Difficulty { get; set; }
      public RouteType RouteType { get; set; }

      public void Mapping(Profile profile) {
         profile.CreateMap<Domain.Entities.Route, RouteDto>()
             .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
             .ForMember(d => d.RouteType, opt => opt.MapFrom(s => s.Type));
      }
   }
}