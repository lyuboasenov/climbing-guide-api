using AutoMapper;
using Climbing.Guide.Api.Application.Behaviours;
using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Application.Routes;
using Climbing.Guide.Api.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Climbing.Guide.Api.Application {
   public static class DependencyInjection {
      public static IServiceCollection AddApplication(this IServiceCollection services) {
         services.AddDomain();
         services.AddSingleton<IStaticContext, StaticContext>();
         services.AddAutoMapper(typeof(DependencyInjection).Assembly);
         services.AddMediatRR(typeof(DependencyInjection).Assembly);
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


         return services;
      }
   }
}
