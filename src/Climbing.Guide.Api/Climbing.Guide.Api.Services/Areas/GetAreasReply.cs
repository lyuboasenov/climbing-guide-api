using AutoMapper;
using Climbing.Guide.Api.Application.Areas.Queries.GetAreasQuery;
using Climbing.Guide.Api.Common.Mappings;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Services.Areas {
   public partial class GetAreasReply : IMapFrom<IGetAreasQueryReply> {
      public void Mapping(Profile profile) {
         profile.CreateMap<IGetAreasQueryReply, GetAreasReply>()
            .IncludeAllDerived()
            .AfterMap((source, destination, context) =>
               destination.Results.AddRange(
                  context.Mapper.Map<IEnumerable<Types.Area>>(source.Results)));
      }

      public partial class Types {
         public partial class Area : IAreaDto, IMapFrom<IAreaDto> {

         }
      }
   }
}
