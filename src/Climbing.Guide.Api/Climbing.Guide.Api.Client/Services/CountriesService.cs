
using Climbing.Guide.Api.Client.ErrorHandling;
using Climbing.Guide.Api.Services;
using System;
using System.Threading.Tasks;
using static Climbing.Guide.Api.Services.Countries;

namespace Climbing.Guide.Api.Client.Services {
   internal class CountriesService : Service<CountriesClient>, ICountriesService {
      public CountriesService(string baseAddress) : base(baseAddress) { }

      public Task<CountriesReply> GetCountriesAsync(int offset, int count) {
         try {
            return Client.GetCountriesAsync(new CountriesRequest() {
               Count = count,
               Offset = offset
            }).ResponseAsync;
         } catch (Exception ex) {
            throw ex.ToCommunicationException();
         }
      }
   }
}
