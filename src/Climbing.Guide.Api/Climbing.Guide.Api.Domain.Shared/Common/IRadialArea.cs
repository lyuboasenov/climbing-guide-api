namespace Climbing.Guide.Api.Domain.Shared.Entities {
   public interface IRadialArea {
      ILocatable Center { get; }
      ushort Radius { get; }
   }
}
