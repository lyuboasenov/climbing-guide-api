using System.Threading.Tasks;
using Climbing.Guide.Api.Services;

namespace Climbing.Guide.Api.Client.Services {
   public interface ICountriesService : IService {
      Task<CountriesReply> GetCountriesAsync(int offset, int count);
   }
}