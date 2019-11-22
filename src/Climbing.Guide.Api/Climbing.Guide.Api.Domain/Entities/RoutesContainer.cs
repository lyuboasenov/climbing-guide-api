using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities {
   public class RoutesContainer : Area {
      public ICollection<Route> Routes { get; } = new HashSet<Route>();
   }
}
