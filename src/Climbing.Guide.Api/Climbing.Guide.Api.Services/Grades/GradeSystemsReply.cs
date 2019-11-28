using AutoMapper;
using Climbing.Guide.Api.Application.Grades.Queries.GetGradeSystemsQuery;
using Climbing.Guide.Api.Common.Mappings;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Services.Grades {
   public partial class GradeSystemsReply : IMapFrom<IGetGradeSystemsQueryReply> {
      public void Mapping(Profile profile) {
         profile.CreateMap<IGetGradeSystemsQueryReply, GradeSystemsReply>()
            .IncludeAllDerived()
            .AfterMap((source, destination, context) =>
               destination.Results.AddRange(
                  context.Mapper.Map<IEnumerable<GradeSystem>>(source.Results)));
      }
   }
}
