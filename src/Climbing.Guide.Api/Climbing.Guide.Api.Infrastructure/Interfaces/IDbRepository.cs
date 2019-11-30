using Climbing.Guide.Api.Application.Interfaces;

namespace Climbing.Guide.Api.Infrastructure.Interfaces {
   public interface IDbRepository : IRepository {
      void EnsureInitialized();
   }
}
