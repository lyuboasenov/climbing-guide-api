using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Climbing.Guide.Api.Common.Mappings {
   public abstract class MappingProfile : Profile {
      protected MappingProfile() {
         ApplyMappingsFromAssembly(this.GetType().Assembly);
      }

      private void ApplyMappingsFromAssembly(Assembly assembly) {
         var types = assembly.GetExportedTypes()
             .Where(t => t.GetInterfaces().Any(i =>
                 i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
             .ToList();

         foreach (var type in types) {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
         }
      }
   }
}
