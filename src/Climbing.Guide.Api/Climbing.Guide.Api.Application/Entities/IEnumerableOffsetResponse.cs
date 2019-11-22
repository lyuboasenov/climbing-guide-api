using System.Collections.Generic;

namespace Climbing.Guide.Api.Application.Entities {
   public interface IEnumerableOffsetResponse<out TResult> {
      int Offset { get; }
      int Count { get; }
      bool HasMore { get; }

      IEnumerable<TResult> Result { get; }
   }
}
