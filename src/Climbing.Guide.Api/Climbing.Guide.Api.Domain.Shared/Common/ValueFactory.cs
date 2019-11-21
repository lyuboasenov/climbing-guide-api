using System;

namespace Climbing.Guide.Api.Domain.Shared.Entities {
   public class ValueFactory : IValueFactory {
      public string CreateId() {
         return Guid.NewGuid().ToString("D");
      }

      public DateTime GetCurrentDateTime() {
         return DateTime.Now;
      }
   }
}
