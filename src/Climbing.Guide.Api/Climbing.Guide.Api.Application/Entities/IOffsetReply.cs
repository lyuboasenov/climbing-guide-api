namespace Climbing.Guide.Api.Application.Entities {
   public interface IOffsetReply {
      int Offset { get; }
      int Count { get; }
      bool HasMore { get; }
   }
}
