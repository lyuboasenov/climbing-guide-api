using AutoMapper;
using Climbing.Guide.Api.Application.Mappings;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   public class RouteListDto : IMapFrom<Domain.Entities.Route> {
      public string Id { get; set; }
      public string AreaId { get; set; }
      public string Name { get; set; }
      public string Schema { get; set; }
      public float Difficulty { get; set; }
      public Common.RouteType RouteType { get; set; }

      public void Mapping(Profile profile) {
         profile.CreateMap<Domain.Entities.Route, RouteListDto>()
             .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
             .ForMember(d => d.RouteType, opt => opt.MapFrom(s => s.Type));
      }
   }
}