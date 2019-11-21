using System;

namespace Climbing.Guide.Api.Domain.Shared.Entities {
   public interface IValueFactory {
      string CreateId();
      DateTime GetCurrentDateTime();
   }
}
