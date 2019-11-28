using AutoMapper;
using Climbing.Guide.Api.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Grades.Queries.GetGradeSystemsQuery {
   public class GetGradeSystemsQueryHandler : IRequestHandler<IGetGradeSystemsQuery, IGetGradeSystemsQueryReply> {
      private readonly IStaticContext _context;
      private readonly IMapper _mapper;

      public GetGradeSystemsQueryHandler(IStaticContext context, IMapper mapper) {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public Task<IGetGradeSystemsQueryReply> Handle(IGetGradeSystemsQuery request, CancellationToken cancellationToken) {
         return Task.FromResult<IGetGradeSystemsQueryReply>(
            new GetGradeSystemsQueryReply() {
               Results = _mapper.Map<GradeSystemDto[]>(_context.GradeSystems)
            });
         ;
      }
   }
}
