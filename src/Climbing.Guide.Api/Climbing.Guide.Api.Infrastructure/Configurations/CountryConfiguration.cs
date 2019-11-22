using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Climbing.Guide.Api.Infrastructure.Configurations {
   public class CountryConfiguration : IEntityTypeConfiguration<Country> {
      public void Configure(EntityTypeBuilder<Country> builder) {
         builder.HasKey(e => e.Id);

         builder.Property(e => e.Id)
            .HasMaxLength(36)
            .ValueGeneratedNever();

         builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(128);

         builder.Property(e => e.Code2)
            .IsRequired()
            .HasMaxLength(2);
         builder.Property(e => e.Code3)
            .IsRequired()
            .HasMaxLength(3);

         builder
            .OwnsOne(e => e.Location);
      }
   }
}
