using AutoMapper;
using AutoMapper.QueryableExtensions;
using Climbing.Guide.Api.Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountriesQuery {
   public class GetCountriesQueryHandler : IRequestHandler<IGetCountriesQuery, IGetCountriesQueryReply> {
      private readonly IDbContext _context;
      private readonly IMapper _mapper;

      public GetCountriesQueryHandler(IDbContext context, IMapper mapper) {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public Task<IGetCountriesQueryReply> Handle(IGetCountriesQuery request, CancellationToken cancellationToken) {
         var countries = _context
            .Countries
            .Skip(request.Offset).Take(request.Count)
            .Take(request.Count)
            .ProjectTo<CountryDto>(_mapper.ConfigurationProvider);

         var count = countries.Count();

         return Task.FromResult<IGetCountriesQueryReply>(new GetCountriesQueryReply() {
            Count = count,
            HasMore = count == request.Count,
            Offset = request.Offset,
            Results = countries
         });
      }
   }
}
