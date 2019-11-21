using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Shared.Entities {
   public interface IFreeArea {
      IEnumerable<ILocatable> Boundaries { get; }
   }
}
