using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.ConsoleClient {
   internal class IoContext {
      internal Task PrintServicesAsync(IEnumerable<Type> availableServices, CancellationToken cancelationToken) {
         Console.Clear();
         Console.WriteLine("Available service(s):");

         int counter = 1;
         foreach(var service in availableServices) {
            Console.WriteLine($"{counter++}. {service.Name}");
         }

         Console.WriteLine();
         Console.WriteLine("Enter Q or q to quit");

         return Task.FromResult(0);
      }

      internal Task<string> GetSelectedServiceAsync(CancellationToken cancelationToken) {
         return Task.FromResult(Console.ReadLine().Trim());
      }

      internal Task PrintInvalidServiceAsync(string selectedServiceName, CancellationToken cancelationToken) {
         Console.WriteLine($"No {selectedServiceName} service found.");

         return Task.FromResult(0);
      }

      internal Task PrintUsingServiceAsync(Type service, CancellationToken cancelationToken) {
         Console.Clear();
         Console.WriteLine($"Service {service.Name} has the following methods:");

         int counter = 1;
         foreach(var method in service.GetMethods()) {
            Console.WriteLine($"{counter++}. {method.Name}");
         }

         Console.WriteLine();
         Console.WriteLine("Enter Q or q to quit");

         return Task.FromResult(0);
      }

      internal Task<string> GetSelectedMethodAsync() {
         return Task.FromResult(Console.ReadLine().Trim());
      }

      internal Task PrintInvalidMethodAsync(string selectedMethodName) {
         Console.WriteLine($"No {selectedMethodName} service found.");

         return Task.FromResult(0);
      }

      internal Task OutputResultAsync(object result, CancellationToken cancelationToken) {
         Console.WriteLine(result);

         return Task.FromResult(0);
      }

      internal Task PrintParameterValueRequestAsync(ParameterInfo parameter, CancellationToken cancelationToken) {
         Console.Write($"Enter {parameter.ParameterType.Name} value for {parameter.Name} parameter: ");

         return Task.FromResult(0);
      }

      internal Task<object> CollectValueStringAsync(CancellationToken cancelationToken) {
         return Task.FromResult<object>(Console.ReadLine().Trim());
      }
   }
}