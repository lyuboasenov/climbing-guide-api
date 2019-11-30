using System.Threading.Tasks;
using Climbing.Guide.Api.Services.Areas;

namespace Climbing.Guide.Api.Client.Services {
   public interface IAreasService : IService {
      Task<GetAreasReply> GetAreasAsync(int offset, int count);
   }
}