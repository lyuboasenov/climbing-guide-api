using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradesQuery {
   internal class GetGradesQueryReply : IGetGradesQueryReply {
      public IEnumerable<IGradeDto> Results { get; set; }
   }
}
