using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Climbing.Guide.Api.Application {
   public static class MediatRExtensions {
      public static IServiceCollection AddMediatRR(this IServiceCollection services, params Assembly[] assemblies) {
         if (!assemblies.Any()) {
            throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for handlers.");
         }
         var serviceConfig = new MediatRServiceConfiguration();

         services.AddTransient<ServiceFactory>(ServiceFactoryImpl);
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
         services.Add(new ServiceDescriptor(typeof(IMediator), serviceConfig.MediatorImplementationType, serviceConfig.Lifetime));

         MediatR.Registration.ServiceRegistrar.AddMediatRClasses(services, assemblies);

         return services;
      }

      public static ServiceFactory ServiceFactoryImpl(IServiceProvider provider) {
         return (type) => {
            var service = provider.GetService(type);
            if (service is null && type.IsHandlerType()) {
               foreach (Type requestType in GetHandlerTypeWithCommandVariations(type)) {
                  service = provider.GetService(type);
                  if (service != null) {
                     break;
                  }
               }
            }

            return service;
         };
      }

      public static bool IsHandlerType(this Type type) {
         return type != null
            && type.IsGenericType
            && type.GetGenericTypeDefinition() == typeof(IRequestHandler<,>);
      }

      public static bool IsRequestType(this Type type, Type commandBaseType) {
         return type != null
            && commandBaseType.IsAssignableFrom(type);
      }

      private static IEnumerable<Type> GetHandlerTypeWithCommandVariations(Type type) {
         if (type.IsHandlerType()) {
            var requestType = type.GenericTypeArguments[0];
            var replyType = type.GenericTypeArguments[1];
            var requestBaseType = typeof(IRequest<>).MakeGenericType(replyType);

            var commandTypeVariations = GetCommandTypeVariations(requestType, requestBaseType).ToArray();
            foreach (var commandVariation in commandTypeVariations) {
               yield return typeof(IRequestHandler<,>).MakeGenericType(commandVariation, replyType);
            }
         }
      }

      private static IEnumerable<Type> GetCommandTypeVariations(Type type, Type requestBaseType) {
         var classType = type.BaseType;

         while (classType != typeof(object)) {
            if (classType.IsRequestType(requestBaseType)) {
               yield return classType;
            }

            classType = classType.BaseType;
         }

         var interfaces = new List<Type>();
         interfaces.AddRange(type.GetInterfaces());

         for (int i = 0; i < interfaces.Count; i++) {
            var @interface = interfaces[i];
            if (@interface != requestBaseType && @interface.IsRequestType(requestBaseType)) {
               yield return @interface;

               var baseInterfaces = @interface.GetInterfaces();
               if (baseInterfaces?.Any() ?? false) {
                  interfaces.AddRange(baseInterfaces);
               }
            }
         }
      }
   }
}
