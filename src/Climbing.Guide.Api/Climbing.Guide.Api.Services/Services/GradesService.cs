using System;
using System.Threading.Tasks;
using AutoMapper;
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

      public async override Task<GetGradeSystemsReply> GetGradeSystems(Empty request, ServerCallContext context) {
         _logger.LogDebug($"GradesService.GetGradeSystems()");

         var appReply = await _mediator.Send(new GetGradeSystemsQuery());
         return _mapper.Map<GetGradeSystemsReply>(appReply);
      }

      public async override Task<GetGradesReply> GetGrades(GetGradesRequest request, ServerCallContext context) {
         _logger.LogDebug($"GradesService.GetGrades({request.Type})");
         var appReply = await _mediator.Send(request);
         return _mapper.Map<GetGradesReply>(appReply);
      }
   }
}
