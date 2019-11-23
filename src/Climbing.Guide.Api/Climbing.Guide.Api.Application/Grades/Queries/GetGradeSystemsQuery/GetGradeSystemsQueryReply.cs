using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradeSystemsQuery {
   internal class GetGradeSystemsQueryReply : IGetGradeSystemsQueryReply {
      public IEnumerable<IGradeSystemDto> Results { get; set; }
   }
}
