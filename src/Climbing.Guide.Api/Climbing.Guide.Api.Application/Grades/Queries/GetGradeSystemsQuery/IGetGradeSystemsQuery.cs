using MediatR;

namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradeSystemsQuery {
   public interface IGetGradeSystemsQuery : IRequest<IGetGradeSystemsQueryReply> {
   }
}