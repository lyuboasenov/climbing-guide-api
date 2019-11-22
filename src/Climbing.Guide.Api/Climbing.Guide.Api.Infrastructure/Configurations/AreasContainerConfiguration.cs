using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Climbing.Guide.Api.Infrastructure.Configurations {
   public class AreasContainerConfiguration : IEntityTypeConfiguration<AreasContainer>{
      public void Configure(EntityTypeBuilder<AreasContainer> builder) {
         builder.HasBaseType(typeof(Area));

         builder
            .HasMany(e => e.Areas)
            .WithOne().OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
      }
   }
}
