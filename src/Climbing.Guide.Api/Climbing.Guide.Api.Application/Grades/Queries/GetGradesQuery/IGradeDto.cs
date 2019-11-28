namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradesQuery {
   public interface IGradeDto {
      Entities.GradeSystemType GradeType { get; }
      string Name { get; }
      double Value { get; }
   }
}