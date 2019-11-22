using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Climbing.Guide.Api.Infrastructure.Configurations {
   public class RouteConfiguration : IEntityTypeConfiguration<Route> {
      public void Configure(EntityTypeBuilder<Route> builder) {
         builder.HasKey(e => e.Id);

         builder.Property(e => e.Id)
            .HasMaxLength(36)
            .ValueGeneratedNever();

         builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(128);

         builder.HasOne(e => e.Area)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

         builder.Property(e => e.Approach).HasColumnType("ntext");
         builder.Property(e => e.History).HasColumnType("ntext");
         builder.Property(e => e.Info).HasColumnType("ntext");

         builder
            .OwnsOne(e => e.Location);

         builder
            .OwnsMany(e => e.Topo)
            .Property(s => s.X)
            .IsRequired();

         builder
            .OwnsMany(e => e.Topo, cb => {
               cb.Property(c => c.X).IsRequired();
               cb.Property(c => c.Y).IsRequired();
            });

         builder
            .HasOne(e => e.CreatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

         builder.Property(e => e.ConcurrencyToken)
            .IsConcurrencyToken();
      }
   }
}
