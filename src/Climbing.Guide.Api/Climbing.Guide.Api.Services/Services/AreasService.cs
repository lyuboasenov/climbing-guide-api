using AutoMapper;
using Climbing.Guide.Api.Application.Areas.Queries.GetAreasQuery;
using Climbing.Guide.Api.Services.Areas;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Services.Services {
   public class AreasService : Areas.AreasService.AreasServiceBase {
      private readonly ILogger<GradesService> _logger;
      private readonly IMediator _mediator;
      private readonly IMapper _mapper;

      public AreasService(ILogger<GradesService> logger, IMediator mediator, IMapper mapper) {
         _logger = logger ?? throw new ArgumentNullException(nameof(logger));
         _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async override Task<GetAreasReply> GetAreas(GetAreasRequest request, ServerCallContext context) {
         _logger.LogDebug($"AreasService.GetAreas({request.Offset}, {request.Count})");

         var result = await _mediator.Send(request);
         return _mapper.Map<IGetAreasQueryReply, GetAreasReply>(result);
      }
   }
}
