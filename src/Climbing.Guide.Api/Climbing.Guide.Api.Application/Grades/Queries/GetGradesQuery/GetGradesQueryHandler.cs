using AutoMapper;
using Climbing.Guide.Api.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradesQuery {
   public class GetGradesQueryHandler : IRequestHandler<IGetGradesQuery, IGetGradesQueryReply> {
      private readonly IMapper _mapper;
      private readonly IStaticContext _context;

      public GetGradesQueryHandler(IStaticContext context, IMapper mapper) {
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
         _context = context ?? throw new ArgumentNullException(nameof(context));
      }

      public Task<IGetGradesQueryReply> Handle(IGetGradesQuery request, CancellationToken cancellationToken) {
         return Task.FromResult<IGetGradesQueryReply>(
            new GetGradesQueryReply() {
               Results = _mapper.Map< GradeDto[]>(_context
                  .GetGrades((Domain.Entities.GradeSystemType) request.GradeSystemType))
            });
      }
   }
}
