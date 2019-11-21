namespace Climbing.Guide.Api.Application.Interfaces {
   public interface ICurrentUser {
      string Id { get; }
      string Name { get; }
      bool IsInRole(string role);
   }
}
