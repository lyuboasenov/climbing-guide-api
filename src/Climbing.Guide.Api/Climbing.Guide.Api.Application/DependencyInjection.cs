using AutoMapper;
using Climbing.Guide.Api.Application.Behaviours;
using Climbing.Guide.Api.Application.Routes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Climbing.Guide.Api.Application {
   public static class DependencyInjection {
      public static IServiceCollection AddApplication(this IServiceCollection services) {
         services.AddAutoMapper(Assembly.GetExecutingAssembly());
         services.AddMediatR(Assembly.GetExecutingAssembly());
         services.AddDomain();
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

         return services;
      }
   }
}
