using System;
using System.Collections.Generic;
using System.Text;

namespace Climbing.Guide.Api.Client.ErrorHandling {
   public class CommunicationException : Exception {
      public CommunicationException() : base() {
      }

      public CommunicationException(string message) : base(message) {
      }

      public CommunicationException(string message, Exception innerException) : base(message, innerException) {
      }
   }
}
