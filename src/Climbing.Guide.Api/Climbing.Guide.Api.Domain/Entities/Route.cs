using Climbing.Guide.Api.Domain.Common;
using System;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities {
   public class Route : IRevisionable, ILocatable, IAuditable, IIdentifiable {
      public string Id { get; set; }
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
      public Area Area { get; set; }
      public float Difficulty { get; set; }
      public float Rating { get; set; }
      public ushort Length { get; set; }
      public string Name { get; set; }
      public string Info { get; set; }
      public string Approach { get; set; }
      public string History { get; set; }
      public RouteType Type { get; set; }
      public ICollection<TopoPoint> Topo { get; } = new HashSet<TopoPoint>();
      public byte[] ConcurrencyToken { get; set; }
      public int Revision { get; set; }
   }
}
