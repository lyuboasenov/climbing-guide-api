using Climbing.Guide.Api.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities {
   public class Route : IRevisionable, ILocatable, IAuditable, IIdentifiable, ITagable {
      public string Id { get; set; }
      public EntityStatus Status { get; set; }
      public DateTime CreatedOn { get; set; }
      public User CreatedBy { get; set; }
      public DateTime? UpdatedOn { get; set; }
      public User UpdatedBy { get; set; }
      public DateTime? ApprovedOn { get; set; }
      public User ApprovedBy { get; set; }
      #region ILocatable
      public Location Location { get; set; }
      #endregion ILocatable
      public Area Area { get; set; }
      public double Difficulty { get; set; }
      public float Rating { get; set; }
      public ushort Length { get; set; }
      public string Name { get; set; }
      public string Info { get; set; }
      public string Approach { get; set; }
      public string History { get; set; }
      public RouteType Type { get; set; }
      public ICollection<SchemaPoint> Topo { get; } = new HashSet<SchemaPoint>();
      public byte[] ConcurrencyToken { get; set; }
      public int Revision { get; set; }
      public ICollection<string> Tags { get; } = new HashSet<string>();
   }
}
