using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Climbing.Guide.Api.Infrastructure.Configurations {
   public class RoutesContainerConfiguration : IEntityTypeConfiguration<RoutesContainer> {
      public void Configure(EntityTypeBuilder<RoutesContainer> builder) {
         builder.HasBaseType(typeof(Area));

         builder
            .HasMany(e => e.Routes)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
      }
   }
}
