using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Entities {
   public interface IEnumerableReply<out TResult> {
      IEnumerable<TResult> Results { get; }
   }
}
