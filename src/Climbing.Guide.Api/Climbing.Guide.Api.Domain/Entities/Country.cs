using Climbing.Guide.Api.Domain.Common;

namespace Climbing.Guide.Api.Domain.Entities {
   public class Country : IIdentifiable, ILocatable {
      public string Id { get; set; }
      public string Code2 { get; set; }
      public string Code3 { get; set; }
      public string Name { get; set; }
      public double Latitude { get; set; }
      public double Longitude { get; set; }
   }
}
