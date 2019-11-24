using AutoMapper;
using Climbing.Guide.Api.Common.Mappings;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountriesQuery {
   internal class CountryDto : IMapFrom<Domain.Entities.Country>, ICountryDto {
      public string Id { get; set; }
      public string Name { get; set; }
      public string Code2 { get; set; }
      public string Code3 { get; set; }
      public double Latitude { get; set; }
      public double Longitude { get; set; }

      public void Mapping(Profile profile) {
         profile.CreateMap<Domain.Entities.Country, CountryDto>()
             .ForMember(d => d.Latitude, opt => opt.MapFrom(s => s.Location.Latitude))
             .ForMember(d => d.Longitude, opt => opt.MapFrom(s => s.Location.Longitude));
      }
   }
}
