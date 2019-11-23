using Climbing.Guide.Api.Application.Grades.Entities;
using MediatR;

namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradesQuery {
   public interface IGetGradesQuery : IRequest<IGetGradesQueryReply> {
      GradeSystemType GradeSystemType { get; }
   }
}
