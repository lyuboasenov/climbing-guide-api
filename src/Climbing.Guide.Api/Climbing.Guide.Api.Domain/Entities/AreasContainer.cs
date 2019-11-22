using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities {
   public class AreasContainer : Area {
      public ICollection<Area> Areas { get; } = new HashSet<Area>();
   }
}
