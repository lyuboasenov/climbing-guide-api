using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.ConsoleClient {
   internal class ClientExecutionSystem {
      private Client.Client _client;
      private IoContext _ioContext;
      private IEnumerable<Type> _availableServices;

      public ClientExecutionSystem() {
         _client = new Client.Client("https://localhost:5001", "https://localhost:5101");
         _ioContext = new IoContext();
         _availableServices = _client.GetAvailableServices();
      }

      public Task RunAsync() {
         return RunAsync(CancellationToken.None);
      }

      public async Task RunAsync(CancellationToken cancelationToken) {
         while(true) {
            await _ioContext.PrintServicesAsync(_availableServices, cancelationToken);
            string selectedServiceName = await _ioContext.GetSelectedServiceAsync(cancelationToken);

            if (CheckIsQuitting(selectedServiceName)) {
               break;
            }

            var selectedService = _availableServices.FirstOrDefault(t => string.Compare(t.Name, selectedServiceName, true) == 0);
            if (selectedService is null) {
               await _ioContext.PrintInvalidServiceAsync(selectedServiceName, cancelationToken);
               continue;
            }

            await UseServiceAsync(selectedService, cancelationToken);
            cancelationToken.ThrowIfCancellationRequested();
         }
      }

      private async Task UseServiceAsync(Type service, CancellationToken cancelationToken) {
         var methods = service.GetMethods();
         while (true) {
            await _ioContext.PrintUsingServiceAsync(service, cancelationToken);
            string selectedMethodName = await _ioContext.GetSelectedMethodAsync();

            if (CheckIsQuitting(selectedMethodName)) {
               break;
            }

            var selectedMethod = methods.FirstOrDefault(m => string.Compare(m.Name, selectedMethodName, true) == 0);
            if (selectedMethod is null) {
               await _ioContext.PrintInvalidMethodAsync(selectedMethodName);
               continue;
            }

            await ExecuteMethodAsync(service, selectedMethod, cancelationToken);
            cancelationToken.ThrowIfCancellationRequested();
         }
      }

      private async Task ExecuteMethodAsync(Type serviceType, MethodInfo method, CancellationToken cancelationToken) {
         var parameters = method.GetParameters();

         var values = await CollectParametersAsync(parameters, cancelationToken);

         if (parameters?.Length == values?.Count()) {
            var service = _client.GetService(serviceType);

            var result = method.Invoke(service, values.ToArray());

            await _ioContext.OutputResultAsync(result, cancelationToken);
         }
      }

      private async Task<IEnumerable<object>> CollectParametersAsync(ParameterInfo[] parameters, CancellationToken cancelationToken) {
         var result = new List<object>();
         foreach(var parameter in parameters ?? Enumerable.Empty<ParameterInfo>()) {
            await _ioContext.PrintParameterValueRequestAsync(parameter, cancelationToken);
            var rawValue = await _ioContext.CollectValueStringAsync(cancelationToken);
            result.Add(Convert.ChangeType(rawValue, parameter.ParameterType));
         }

         return result;
      }

      private bool CheckIsQuitting(string input) {
         return string.Compare(input, "q", true) == 0 || string.Compare(input, "quit", true) == 0;
      }
   }
}
