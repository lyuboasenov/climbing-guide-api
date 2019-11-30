using System;

namespace Climbing.Guide.Api.Domain.Entities.Interfaces {
   public interface IAuditable {
      User CreatedBy { get; set; }
      DateTime CreatedOn { get; set; }
      User UpdatedBy { get; set; }
      DateTime? UpdatedOn { get; set; }
   }
}
