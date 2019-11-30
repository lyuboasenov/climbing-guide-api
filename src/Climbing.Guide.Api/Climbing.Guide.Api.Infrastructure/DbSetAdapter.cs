using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Infrastructure {
   internal class DbSetAdapter<TEntity> : Application.Interfaces.ISet<TEntity> where TEntity : class {
      private readonly DbSet<TEntity> _dbSet;
      public DbSetAdapter(DbSet<TEntity> dbSet) {
         _dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
      }

      public Type ElementType => (_dbSet as IQueryable)?.ElementType;
      public Expression Expression => (_dbSet as IQueryable)?.Expression;
      public IQueryProvider Provider => (_dbSet as IQueryable)?.Provider;

      public TEntity Add(TEntity entity) {
         return _dbSet.Add(entity).Entity;
      }

      public async ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken)) {
          var result = await _dbSet.AddAsync(entity, cancellationToken);
         return result.Entity;
      }

      public void AddRange(params TEntity[] entities) {
         _dbSet.AddRange(entities);
      }

      public void AddRange(IEnumerable<TEntity> entities) {
         _dbSet.AddRange(entities);
      }

      public Task AddRangeAsync(params TEntity[] entities) {
         return _dbSet.AddRangeAsync(entities);
      }

      public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken)) {
         return _dbSet.AddRangeAsync(entities, cancellationToken);
      }

      public TEntity Find(params object[] keyValues) {
         return _dbSet.Find(keyValues);
      }

      public ValueTask<TEntity> FindAsync(params object[] keyValues) {
         return _dbSet.FindAsync(keyValues);
      }

      public ValueTask<TEntity> FindAsync(IEnumerable<object> keyValues, CancellationToken cancellationToken = default(CancellationToken)) {
         return _dbSet.FindAsync(keyValues, cancellationToken);
      }

      public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken)) {
         return (_dbSet as IAsyncEnumerable<TEntity>).GetAsyncEnumerator(cancellationToken);
      }

      public IEnumerator<TEntity> GetEnumerator() {
         return (_dbSet as IEnumerable<TEntity>).GetEnumerator();
      }

      public TEntity Remove(TEntity entity) {
         return _dbSet.Remove(entity).Entity;
      }

      public void RemoveRange(params TEntity[] entities) {
         _dbSet.RemoveRange(entities);
      }

      public void RemoveRange(IEnumerable<TEntity> entities) {
         _dbSet.RemoveRange(entities);
      }

      public TEntity Update(TEntity entity) {
         return _dbSet.Update(entity).Entity;
      }

      public void UpdateRange(params TEntity[] entities) {
         _dbSet.UpdateRange(entities);
      }

      public void UpdateRange(IEnumerable<TEntity> entities) {
         _dbSet.UpdateRange(entities);
      }

      IEnumerator IEnumerable.GetEnumerator() {
         return (_dbSet as IEnumerable<TEntity>).GetEnumerator();
      }
   }
}
