using Climbing.Guide.Api.Common.Mappings;
using Climbing.Guide.Api.Domain.Entities;

namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradeSystemsQuery {
   internal class GradeSystemDto : IMapFrom<GradeSystem>, IGradeSystemDto {
      public Entities.GradeSystemType GradeType { get; set; }
      public Routes.Entities.RouteType RouteType { get; set; }
      public string Name { get; set; }
   }
}
