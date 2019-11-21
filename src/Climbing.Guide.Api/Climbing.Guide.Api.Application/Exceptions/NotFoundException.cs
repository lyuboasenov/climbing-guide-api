using System;

namespace Climbing.Guide.Api.Application.Exceptions {
   public class NotFoundException : Exception {
      public NotFoundException(Type entityType, object key)
          : base($"Entity \"{entityType}\" ({key}) was not found.") {
      }

      public NotFoundException() : base() {
      }

      public NotFoundException(string message) : base(message) {
      }

      public NotFoundException(string message, Exception innerException) : base(message, innerException) {
      }
   }
}
