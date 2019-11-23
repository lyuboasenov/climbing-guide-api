namespace Climbing.Guide.Api.Application.Entities {
   public interface IOffsetReply<out TResult> {
      int Offset { get; }
      int Count { get; }
      bool HasMore { get; }
   }
}
