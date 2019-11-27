using Microsoft.EntityFrameworkCore;

namespace Climbing.Guide.Api.Infrastructure.DataSeed {
   public class DataSeedingContext : DbContext {
      public DataSeedingContext(DbContextOptions<DbContext> options) : base(options) {

      }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         base.OnModelCreating(modelBuilder);
         modelBuilder.EnsureSeedData();
      }
   }
}
