using Climbing.Guide.Api.Domain.Implementations;
using Climbing.Guide.Api.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Climbing.Guide.Api.Application.Routes {
   public static class DependencyInjection {
      public static IServiceCollection AddDomain(this IServiceCollection services) {
         services.AddTransient(typeof(IValueFactory), typeof(ValueFactory));

         return services;
      }
   }
}
