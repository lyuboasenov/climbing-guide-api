using AutoMapper;
using Climbing.Guide.Api.Common.Mappings;
using Climbing.Guide.Api.Domain.Entities;

namespace Climbing.Guide.Api.Application.Areas.Queries.GetAreasQuery {
   internal class AreaDto : IAreaDto, IMapFrom<Area> {
      public string Id { get; set; }
      public string ParentId { get; set; }
      public string Name { get; set; }
      public string Info { get; set; }
      public double Latitude { get; set; }
      public double Longitude { get; set; }
      public int AreasCount { get; set; }
      public int RoutesCount { get; set; }

      public void Mapping(Profile profile) {
         profile.CreateMap<Area, AreaDto>()
            .IncludeAllDerived()
            .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.Parent.Id));
      }
   }
}