using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Climbing.Guide.Api.Infrastructure.Configurations {
   public class RouteConfiguration : IEntityTypeConfiguration<Route> {
      public void Configure(EntityTypeBuilder<Route> builder) {
         builder.Property(e => e.Id)
            .HasMaxLength(36);
         builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(128);
         builder.Property(e => e.Area)
            .IsRequired();
         builder.Property(e => e.CreatedBy)
            .IsRequired();
         builder.Property(e => e.ConcurrencyToken)
            .IsConcurrencyToken();
         builder.Property(e => e.Approach).HasColumnType("ntext");
         builder.Property(e => e.History).HasColumnType("ntext");
         builder.Property(e => e.Info).HasColumnType("ntext");
      }
   }
}
