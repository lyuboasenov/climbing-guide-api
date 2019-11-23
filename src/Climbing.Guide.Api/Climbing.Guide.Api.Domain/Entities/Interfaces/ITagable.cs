using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities.Interfaces {
   public interface ITagable {
      ICollection<string> Tags { get; }
   }
}