using Climbing.Guide.Api.Application.Grades.Entities;
using Climbing.Guide.Api.Application.Routes.Entities;

namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradeSystemsQuery {
   public interface IGradeSystemDto {
      GradeSystemType GradeType { get; set; }
      string Name { get; set; }
      RouteType RouteType { get; set; }
   }
}