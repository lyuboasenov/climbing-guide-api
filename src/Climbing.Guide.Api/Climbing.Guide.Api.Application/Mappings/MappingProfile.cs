using System;
using System.Linq;
using System.Reflection;

namespace Climbing.Guide.Api.Application.Mappings {
   internal class MappingProfile {
      public MappingProfile() {
         ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
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
