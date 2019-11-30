using AutoMapper;
using Climbing.Guide.Api.Application.Grades.Queries.GetGradesQuery;
using Climbing.Guide.Api.Common.Mappings;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Services.Grades {
   public partial class GetGradesReply : IMapFrom<IGetGradesQueryReply> {
      public void Mapping(Profile profile) {
         profile.CreateMap<IGetGradesQueryReply, GetGradesReply>()
            .IncludeAllDerived()
            .AfterMap((source, destination, context) =>
               destination.Results.AddRange(
                  context.Mapper.Map<IEnumerable<Grade>>(source.Results)));
      }
   }
}
