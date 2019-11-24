using System;
using System.Threading.Tasks;
using AutoMapper;
using Climbing.Guide.Api.Application.Grades.Queries.GetGradeSystemsQuery;
using Climbing.Guide.Api.Services.Grades;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Climbing.Guide.Api.Services {
   public class GradesService : Grades.GradesService.GradesServiceBase {
      private readonly ILogger<GradesService> _logger;
      private readonly IMediator _mediator;
      private readonly IMapper _mapper;

      public GradesService(ILogger<GradesService> logger, IMediator mediator, IMapper mapper) {
         _logger = logger;
         _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async override Task<GradeSystemsReply> GetGradeSystems(Empty request, ServerCallContext context) {
         _logger.LogDebug($"GradesService.GetGradeSystems()");

         IGetGradeSystemsQuery casedRequest = new GetGradeSystemsQuery();

         try {
            var appReply1 = await _mediator.Send(casedRequest);
         }catch {

         }

         var appReply = await _mediator.Send((IGetGradeSystemsQuery) new GetGradeSystemsQuery());
         return _mapper.Map<GradeSystemsReply>(appReply);
      }

      public async override Task<GradesReply> GetGrades(GradesRequest request, ServerCallContext context) {
         _logger.LogDebug($"GradesService.GetGrades({request.Type})");
         var appReply = await _mediator.Send(request);
         return _mapper.Map<GradesReply>(appReply);
      }
   }
}
