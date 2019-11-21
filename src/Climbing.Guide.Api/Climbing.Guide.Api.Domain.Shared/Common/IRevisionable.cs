namespace Climbing.Guide.Api.Domain.Shared.Entities {
   public interface IRevisionable {
      int Revision { get; set; }
      byte[] ConcurrencyToken { get; set; }
   }
}
