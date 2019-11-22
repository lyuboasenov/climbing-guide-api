using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities {
   public class Location : ValueObject.ValueObject {
      public Location(double latitude, double longitude) {
         Latitude = latitude;
         Longitude = longitude;
      }

      public double Latitude { get; set; }
      public double Longitude { get; set; }

      protected override IEnumerable<object> GetAtomicValues() {
         yield return Latitude;
         yield return Longitude;
      }
   }
}
