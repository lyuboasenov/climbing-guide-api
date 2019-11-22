using Climbing.Guide.Api.Application.Interfaces;

namespace Climbing.Guide.Api.Services.Services {
   public class CurrentUserService : ICurrentUserService {
      public string Id { get; } = "static-id";
      public string Name { get; } = "static user";

      public bool IsInRole(string role) {
         return false;
      }
   }
}
