using AutoMapper;
using Climbing.Guide.Api.Application.Mappings;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountryListQuery {
   internal class CountryListDto : IMapFrom<Domain.Entities.Country>, ICountryListDto {
      public string Id { get; set; }
      public string Name { get; set; }
      public string Code2 { get; set; }
      public string Code3 { get; set; }
      public double Latitude { get; set; }
      public double Longitude { get; set; }

      public void Mapping(Profile profile) {
         profile.CreateMap<Domain.Entities.Country, CountryListDto>()
             .ForMember(d => d.Latitude, opt => opt.MapFrom(s => s.Location.Latitude))
             .ForMember(d => d.Longitude, opt => opt.MapFrom(s => s.Location.Longitude));
      }
   }
}
