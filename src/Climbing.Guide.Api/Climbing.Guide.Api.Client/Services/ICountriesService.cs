using System.Threading.Tasks;
using Climbing.Guide.Api.Services.Countries;

namespace Climbing.Guide.Api.Client.Services {
   public interface ICountriesService : IService {
      Task<GetCountriesReply> GetCountriesAsync(int offset, int count);
   }
}