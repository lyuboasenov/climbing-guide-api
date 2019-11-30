using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Interfaces {
   public interface IRepository {
      DbSet<Route> Routes { get; }
      DbSet<Area> Areas { get; }
      DbSet<User> Users { get; }
      DbSet<Country> Countries { get; }

      Task<int> SaveChangesAsync(CancellationToken cancellationToken);
   }
}
