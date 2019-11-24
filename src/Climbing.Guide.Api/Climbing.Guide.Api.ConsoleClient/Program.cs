using System;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.ConsoleClient {
   class Program {
      static async Task Main(string[] args) {
         var client = new ClientExecutionSystem();
         await client.RunAsync();
      }
   }
}
