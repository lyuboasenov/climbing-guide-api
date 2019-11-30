using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Climbing.Guide.Api.Infrastructure {
   public static class DependencyInjection {
      public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
         services.AddDbContext<DbRepository>(options =>
             options
               .UseSqlServer(configuration.GetConnectionString("ClimbingGuideConnectionString"))
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging());

         services.AddScoped<IDbRepository>(provider => provider.GetService<DbRepository>());
         services.AddScoped<IRepository>(provider => provider.GetService<IDbRepository>());
         services.AddScoped<IFsContext>(provider => provider.GetService<FsContext>());
         services.AddScoped<IImageUtil>(provider => provider.GetService<ImageUtil>());

         return services;
      }
   }
}
