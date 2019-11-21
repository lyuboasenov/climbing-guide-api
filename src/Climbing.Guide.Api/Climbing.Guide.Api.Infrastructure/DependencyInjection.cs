using Climbing.Guide.Api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Climbing.Guide.Api.Infrastructure {
   public static class DependencyInjection {
      public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
         services.AddDbContext<DbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("RoutesDatabase")));

         services.AddScoped<IDbContext>(provider => provider.GetService<DbContext>());
         services.AddScoped<IFsContext>(provider => provider.GetService<FsContext>());
         services.AddScoped<IImageUtil>(provider => provider.GetService<ImageUtil>());

         return services;
      }
   }
}
