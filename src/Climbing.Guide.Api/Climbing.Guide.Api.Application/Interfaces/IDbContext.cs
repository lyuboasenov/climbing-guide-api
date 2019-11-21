using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Interfaces {
   public interface IDbContext {
      DbSet<Route> Routes { get; set; }
      DbSet<Area> Areas { get; set; }
      DbSet<User> Users { get; set; }

      Task<int> SaveChangesAsync(CancellationToken cancellationToken);
   }
}
