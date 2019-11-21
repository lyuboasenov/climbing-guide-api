using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities {
   public class TopoPoint : ValueObject.ValueObject {
      public double X { get; }
      public double Y { get; }

      public TopoPoint() {

      }

      public TopoPoint(double x, double y) {
         X = x;
         Y = y;
      }

      protected override IEnumerable<object> GetAtomicValues() {
         yield return X;
         yield return Y;
      }
   }
}