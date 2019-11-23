using Climbing.Guide.Api.Application.Exceptions;
using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Domain.Entities;
using Climbing.Guide.Api.Domain.Entities.Interfaces;
using Climbing.Guide.Api.Domain.Services;
using Climbing.Guide.Api.Infrastructure.DataSeed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Infrastructure {
   public class DbContext : Microsoft.EntityFrameworkCore.DbContext, IDbContext {
      public DbSet<Route> Routes { get; set; }
      public DbSet<Area> Areas { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<Country> Countries { get; set; }

      private readonly ICurrentUserService _currentUser;
      private readonly IValueFactory _valueFactory;

      public DbContext(DbContextOptions<DbContext> options)
            : base(options) {
      }

      public DbContext(DbContextOptions<DbContext> options,
         ICurrentUserService currentUser,
         IValueFactory valueFactory)
            : base(options) {
         _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
         _valueFactory = valueFactory ?? throw new ArgumentNullException(nameof(valueFactory));
      }

      public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
         var currentUser = await Users.FindAsync(_currentUser.Id) ?? throw new NotFoundException(typeof(User), _currentUser.Id);
         var date = _valueFactory.GetCurrentDateTime();
         foreach (var entry in ChangeTracker.Entries<IAuditable>()) {
            switch (entry.State) {
               case EntityState.Added:
                  entry.Entity.CreatedBy = currentUser;
                  entry.Entity.CreatedOn = date;
                  break;
               case EntityState.Modified:
                  entry.Entity.UpdatedBy = currentUser;
                  entry.Entity.UpdatedOn = date;
                  break;
            }
         }

         foreach (var entry in ChangeTracker.Entries<IRevisionable>()) {
            switch (entry.State) {
               case EntityState.Added:
                  entry.Entity.Revision = 1;
                  break;
               case EntityState.Modified:
                  entry.Entity.Revision++;
                  break;
            }
         }

         return await base.SaveChangesAsync(cancellationToken);
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
         modelBuilder.EnsureSeedData();
      }
   }
}
