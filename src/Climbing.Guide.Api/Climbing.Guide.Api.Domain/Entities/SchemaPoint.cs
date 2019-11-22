using System.Collections.Generic;

namespace Climbing.Guide.Api.Domain.Entities {
   public class SchemaPoint : ValueObject.ValueObject {
      public double X { get; }
      public double Y { get; }

      public SchemaPoint() {

      }

      public SchemaPoint(double x, double y) {
         X = x;
         Y = y;
      }

      protected override IEnumerable<object> GetAtomicValues() {
         yield return X;
         yield return Y;
      }
   }
}