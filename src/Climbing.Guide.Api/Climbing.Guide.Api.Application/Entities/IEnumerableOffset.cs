namespace Climbing.Guide.Api.Application.Entities {
   public interface IEnumerableOffset {
      int Offset { get; }
      int Count { get; }
      bool HasMore { get; }
   }
}
