using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Entities {
   public interface IEnumerableOffsetQuery {
      int Offset { get; set; }
      int Count { get; set; }
   }
}
