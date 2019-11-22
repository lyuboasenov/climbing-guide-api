using AutoMapper;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Services.Services {
   public class CountriesService : Countries.CountriesBase {
      private readonly ILogger<GradesService> _logger;
      private readonly IMediator _mediator;
      private readonly IMapper _mapper;

      public CountriesService(ILogger<GradesService> logger, IMediator mediator, IMapper mapper) {
         _logger = logger ?? throw new ArgumentNullException(nameof(logger));
         _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async override Task<CountriesReply> GetCountries(CountriesRequest request, ServerCallContext context) {
         var result = await _mediator.Send(request);

         return _mapper.Map<CountriesReply>(result);
      }
   }
}
