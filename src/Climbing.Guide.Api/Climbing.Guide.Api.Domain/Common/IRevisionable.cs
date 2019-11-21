namespace Climbing.Guide.Api.Domain.Common {
   public interface IRevisionable {
      int Revision { get; set; }
      byte[] ConcurrencyToken { get; set; }
   }
}
