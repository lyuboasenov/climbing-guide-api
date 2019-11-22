using Climbing.Guide.Api.Client.ErrorHandling;
using Climbing.Guide.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Climbing.Guide.Api.Services.Grades;

namespace Climbing.Guide.Api.Client.Services {
   internal class GradesService : Service<GradesClient>, IGradesService {
      public GradesService(string baseAddress) : base(baseAddress) {

      }

      public async Task<IEnumerable<GradeSystem>> GetGradeSystemsAsync() {
         try {
            var reply = await Client.GetGradeSystemsAsync(new Google.Protobuf.WellKnownTypes.Empty());
            return reply.GradeSystems;
         } catch (Exception ex) {
            throw ex.ToCommunicationException();
         }
      }

      public async Task<IEnumerable<Grade>> GetGradesAsync(GradeSystemType type) {
         try {
            var reply = await Client.GetGradesAsync(new GradesRequest() {
               Type = type
            });
            return reply.Grades;
         } catch (Exception ex) {
            throw ex.ToCommunicationException();
         }
      }
   }
}
