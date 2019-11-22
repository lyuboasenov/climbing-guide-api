using Climbing.Guide.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Client.Services {
   public interface IGradesService : IService {
      Task<IEnumerable<Grade>> GetGradesAsync(GradeSystemType type);
      Task<IEnumerable<GradeSystem>> GetGradeSystemsAsync();
   }
}