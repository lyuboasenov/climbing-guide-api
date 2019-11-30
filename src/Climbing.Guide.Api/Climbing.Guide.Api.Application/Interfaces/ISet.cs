using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Interfaces {
   public interface ISet<TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity> where TEntity : class {
      TEntity Find(params object[] keyValues);
      ValueTask<TEntity> FindAsync(params object[] keyValues);
      ValueTask<TEntity> FindAsync(IEnumerable<object> keyValues, CancellationToken cancellationToken = default);

      TEntity Add(TEntity entity);
      ValueTask<TEntity> AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default);

      void AddRange(params TEntity[] entities);
      void AddRange(IEnumerable<TEntity> entities);
      Task AddRangeAsync(params TEntity[] entities);
      Task AddRangeAsync(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default);

      TEntity Update(TEntity entity);
      void UpdateRange(params TEntity[] entities);
      void UpdateRange(IEnumerable<TEntity> entities);

      TEntity Remove(TEntity entity);

      void RemoveRange(params TEntity[] entities);
      void RemoveRange(IEnumerable<TEntity> entities);
   }
}
