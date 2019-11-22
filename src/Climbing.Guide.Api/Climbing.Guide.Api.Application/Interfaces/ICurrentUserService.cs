namespace Climbing.Guide.Api.Application.Interfaces {
   public interface ICurrentUserService {
      string Id { get; }
      string Name { get; }
      bool IsInRole(string role);
   }
}
