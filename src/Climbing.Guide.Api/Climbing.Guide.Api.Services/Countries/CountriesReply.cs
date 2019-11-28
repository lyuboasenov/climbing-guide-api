using AutoMapper;
using Climbing.Guide.Api.Application.Countries.Queries.GetCountriesQuery;
using Climbing.Guide.Api.Common.Mappings;
using System.Linq;

namespace Climbing.Guide.Api.Services.Countries {
   public partial class CountriesReply : IMapFrom<IGetCountriesQueryReply> {
      public void Mapping(Profile profile) {
         profile.CreateMap<IGetCountriesQueryReply, CountriesReply>()
            .IncludeAllDerived()
            .AfterMap((source, destination, context) =>
               destination.Results.AddRange(
                  context.Mapper.ProjectTo<Types.Country>(source.Results.AsQueryable())));
      }

      public partial class Types {
         public partial class Country : IMapFrom<ICountryDto> {

         }
      }
   }
}
