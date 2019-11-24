
using Climbing.Guide.Api.Client.ErrorHandling;
using Climbing.Guide.Api.Services.Countries;
using System;
using System.Threading.Tasks;
using static Climbing.Guide.Api.Services.Countries.CountriesService;

namespace Climbing.Guide.Api.Client.Services {
   internal class CountriesService : Service<CountriesServiceClient>, ICountriesService {
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
