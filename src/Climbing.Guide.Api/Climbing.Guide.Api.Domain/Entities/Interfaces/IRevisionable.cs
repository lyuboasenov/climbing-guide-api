namespace Climbing.Guide.Api.Domain.Entities.Interfaces {
   public interface IRevisionable {
      int Revision { get; set; }
      byte[] ConcurrencyToken { get; set; }
   }
}
