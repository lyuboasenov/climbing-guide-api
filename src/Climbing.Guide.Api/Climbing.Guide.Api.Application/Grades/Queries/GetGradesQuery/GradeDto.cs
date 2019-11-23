using Climbing.Guide.Api.Application.Mappings;
using Climbing.Guide.Api.Domain.Entities;

namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradesQuery {
   internal class GradeDto : IGradeDto, IMapFrom<Grade> {
      public Entities.GradeSystemType GradeType { get; set; }
      public double Value { get; set; }
      public string Name { get; set; }
   }
}