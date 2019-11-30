namespace Climbing.Guide.Api.Application.Areas.Queries.GetAreasQuery {
   public interface IAreaDto {
      string Id { get; }
      string ParentId { get; }
      string Name { get; }
      string Info { get; }
      double Latitude { get; }
      double Longitude { get; }
      int AreasCount { get; }
      int RoutesCount { get; }
   }
}