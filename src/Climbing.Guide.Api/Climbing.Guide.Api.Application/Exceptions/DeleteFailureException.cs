using System;

namespace Climbing.Guide.Api.Application.Exceptions {
   public class DeleteFailureException : Exception {
      public DeleteFailureException(string name, object key, string message)
          : base($"Deletion of entity \"{name}\" ({key}) failed. {message}") {
      }

      public DeleteFailureException() : base() {
      }

      public DeleteFailureException(string message) : base(message) {
      }

      public DeleteFailureException(string message, Exception innerException) : base(message, innerException) {
      }
   }
}
