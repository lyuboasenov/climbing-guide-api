using Climbing.Guide.Api.Domain.Common;

namespace Climbing.Guide.Api.Domain.Entities {
   public class User : IIdentifiable {
      public string Id { get; set; }
      public string Name { get; set; }
   }
}
