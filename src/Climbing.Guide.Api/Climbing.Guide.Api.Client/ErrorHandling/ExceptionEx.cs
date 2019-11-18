using System;
using System.Collections.Generic;
using System.Text;

namespace Climbing.Guide.Api.Client.ErrorHandling {
   internal static class ExceptionEx {
      public static CommunicationException ToCommunicationException(this Exception ex) {
         ex = ex ?? throw new ArgumentNullException(nameof(ex));
         return new CommunicationException(ex.Message, ex);
      }
   }
}
