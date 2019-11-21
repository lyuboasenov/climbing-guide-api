using Climbing.Guide.Api.Domain.Interfaces;
using System;

namespace Climbing.Guide.Api.Domain.Implementations {
   internal class ValueFactory : IValueFactory {
      public string CreateId() {
         return Guid.NewGuid().ToString("D");
      }

      public DateTime GetCurrentDateTime() {
         return DateTime.Now;
      }
   }
}
