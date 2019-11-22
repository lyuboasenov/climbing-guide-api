using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities {
   public interface ITagable {
      ICollection<string> Tags { get; }
   }
}