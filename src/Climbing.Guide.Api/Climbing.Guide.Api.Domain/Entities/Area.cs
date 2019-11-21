using Climbing.Guide.Api.Domain.Common;
using System;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities {
   public class Area : IIdentifiable {
      public string Id { get; set; }
      public Area Parent { get; set; }
      public Country Country { get; set; }
      public string Name { get; set; }
      public string Info { get; set; }
      public string Approach { get; set; }
      public string Descent { get; set; }
      public string History { get; set; }
      public string Ethics { get; set; }
      public string Accomodations { get; set; }
      public string Restrictions { get; set; }
      public ICollection<string> Tags { get; } = new HashSet<string>();
      public EntityStatus Status { get; set; }
      public DateTime CreatedOn { get; set; }
      public User CreatedBy { get; set; }
      public DateTime UpdatedOn { get; set; }
      public User UpdatedBy { get; set; }
      public DateTime ApprovedOn { get; set; }
      public User ApprovedBy { get; set; }
      #region ILocatable
      public double Latitude { get; set; }
      public double Longitude { get; set; }
      #endregion ILocatable
   }
}
