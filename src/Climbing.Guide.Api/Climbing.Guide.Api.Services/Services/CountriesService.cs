using AutoMapper;
using Climbing.Guide.Api.Application.Countries.Queries.GetCountriesQuery;
using Climbing.Guide.Api.Services.Countries;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Services.Services {
   public class CountriesService : Countries.CountriesService.CountriesServiceBase {
      private readonly ILogger<GradesService> _logger;
      private readonly IMediator _mediator;
      private readonly IMapper _mapper;

      public CountriesService(ILogger<GradesService> logger, IMediator mediator, IMapper mapper) {
         _logger = logger ?? throw new ArgumentNullException(nameof(logger));
         _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public async override Task<CountriesReply> GetCountries(CountriesRequest request, ServerCallContext context) {
         _logger.LogDebug($"CountriesService.GetCountries({request.Offset}, {request.Count})");

         var result = await _mediator.Send<IGetCountriesQueryReply>(request);
         return _mapper.Map<CountriesReply>(result);
      }
   }
}
