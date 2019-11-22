using AutoMapper;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountryListQuery {
   public interface ICountryListDto {
      string Code2 { get; }
      string Code3 { get; }
      string Id { get; }
      double Latitude { get; }
      double Longitude { get; }
      string Name { get; }

      void Mapping(Profile profile);
   }
}