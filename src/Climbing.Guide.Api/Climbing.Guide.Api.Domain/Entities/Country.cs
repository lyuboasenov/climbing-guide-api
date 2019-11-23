using Climbing.Guide.Api.Domain.Entities.Interfaces;

namespace Climbing.Guide.Api.Domain.Entities {
   public class Country : IIdentifiable, ILocatable {
      public string Id { get; set; }
      public string Code2 { get; set; }
      public string Code3 { get; set; }
      public string Name { get; set; }
      public Location Location { get; set; }
   }
}
