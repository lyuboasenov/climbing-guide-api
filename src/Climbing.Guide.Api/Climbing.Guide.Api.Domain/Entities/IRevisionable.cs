namespace Climbing.Guide.Api.Domain.Entities {
   public interface IRevisionable {
      int Revision { get; set; }
      byte[] ConcurrencyToken { get; set; }
   }
}
