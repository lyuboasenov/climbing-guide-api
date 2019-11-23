using System;

namespace Climbing.Guide.Api.Domain.Services {
   public interface IValueFactory {
      string CreateId();
      DateTime GetCurrentDateTime();
   }
}
