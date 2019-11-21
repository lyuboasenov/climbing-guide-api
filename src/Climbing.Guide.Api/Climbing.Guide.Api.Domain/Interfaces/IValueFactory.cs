using System;

namespace Climbing.Guide.Api.Domain.Interfaces {
   public interface IValueFactory {
      string CreateId();
      DateTime GetCurrentDateTime();
   }
}
