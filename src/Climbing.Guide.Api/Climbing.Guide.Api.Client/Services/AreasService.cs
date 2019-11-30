
using Climbing.Guide.Api.Client.ErrorHandling;
using Climbing.Guide.Api.Services.Areas;
using Climbing.Guide.Api.Services.Countries;
using System;
using System.Threading.Tasks;
using static Climbing.Guide.Api.Services.Areas.AreasService;

namespace Climbing.Guide.Api.Client.Services {
   internal class AreasService : Service<AreasServiceClient>, IAreasService {
      public AreasService(string baseAddress) : base(baseAddress) { }

      public Task<GetAreasReply> GetAreasAsync(int offset, int count) {
         try {
            return Client.GetAreasAsync(new GetAreasRequest() {
               Count = count,
               Offset = offset
            }).ResponseAsync;
         } catch (Exception ex) {
            throw ex.ToCommunicationException();
         }
      }
   }
}
