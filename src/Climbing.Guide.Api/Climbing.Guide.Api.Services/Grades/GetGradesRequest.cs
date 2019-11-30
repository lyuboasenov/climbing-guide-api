using Climbing.Guide.Api.Application.Grades.Queries.GetGradesQuery;

namespace Climbing.Guide.Api.Services.Grades {
   public partial class GetGradesRequest : IGetGradesQuery {
      public Application.Grades.Entities.GradeSystemType GradeSystemType
         => (Application.Grades.Entities.GradeSystemType) Type;
   }
}
