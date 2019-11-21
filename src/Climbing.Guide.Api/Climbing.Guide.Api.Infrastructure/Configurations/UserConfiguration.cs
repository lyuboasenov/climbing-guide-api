using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Climbing.Guide.Api.Infrastructure.Configurations {
   public class UserConfiguration : IEntityTypeConfiguration<User> {
      public void Configure(EntityTypeBuilder<User> builder) {
         builder.Property(e => e.Id)
            .HasMaxLength(36);
         builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(128);
      }
   }
}
