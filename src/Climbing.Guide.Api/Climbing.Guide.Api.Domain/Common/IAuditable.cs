using Climbing.Guide.Api.Domain.Entities;
using System;

namespace Climbing.Guide.Api.Domain.Common {
   public interface IAuditable {
      User CreatedBy { get; set; }
      DateTime CreatedOn { get; set; }
      User UpdatedBy { get; set; }
      DateTime UpdatedOn { get; set; }
   }
}
