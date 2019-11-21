using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Climbing.Guide.Api.Infrastructure.Configurations {
   public class AreaConfiguration : IEntityTypeConfiguration<Area> {
      public void Configure(EntityTypeBuilder<Area> builder) {
         builder.Property(e => e.Id)
            .HasMaxLength(36);
         builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(128);
      }
   }
}
