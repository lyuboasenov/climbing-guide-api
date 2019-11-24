using Climbing.Guide.Api.Client.ErrorHandling;
using Climbing.Guide.Api.Services.Grades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Climbing.Guide.Api.Services.Grades.GradesService;

namespace Climbing.Guide.Api.Client.Services {
   internal class GradesService : Service<GradesServiceClient>, IGradesService {
      public GradesService(string baseAddress) : base(baseAddress) {

      }

      public async Task<IEnumerable<GradeSystem>> GetGradeSystemsAsync() {
         try {
            var reply = await Client.GetGradeSystemsAsync(new Google.Protobuf.WellKnownTypes.Empty());
            return reply.Results;
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
