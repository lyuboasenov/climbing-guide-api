using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Climbing.Guide.Api.Infrastructure.Configurations {
   public class AreaConfiguration : IEntityTypeConfiguration<Area> {
      public void Configure(EntityTypeBuilder<Area> builder) {
         builder
            .ToTable(nameof(Area))
            .HasKey(e => e.Id);

         builder
            .Property(e => e.Id)
            .HasMaxLength(36);

         builder
            .HasOne(e => e.Parent)
            .WithMany().OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

         builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(128);

         builder
            .OwnsOne(e => e.Location);

         builder
            .HasOne(e => e.Country)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

         builder
            .Property(e => e.Approach)
            .HasColumnType("ntext");
         builder
            .Property(e => e.Descent)
            .HasColumnType("ntext");
         builder
            .Property(e => e.Ethics)
            .HasColumnType("ntext");
         builder
            .Property(e => e.History)
            .HasColumnType("ntext");
         builder
            .Property(e => e.Info)
            .HasColumnType("ntext");
         builder
            .Property(e => e.Accomodations)
            .HasColumnType("ntext");
         builder
            .Property(e => e.Restrictions)
            .HasColumnType("ntext");

         builder
            .HasOne(e => e.CreatedBy)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

         builder
            .Property(e => e.ConcurrencyToken)
            .IsConcurrencyToken();
      }
   }
}
