using AutoMapper;
using AutoMapper.QueryableExtensions;
using Climbing.Guide.Api.Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Countries.Queries.GetCountryListQuery {
   public class GetCountryListQueryHandler : IRequestHandler<IGetCountryListQuery, IGetCountryListQueryResponse> {
      private readonly IDbContext _context;
      private readonly IMapper _mapper;

      public GetCountryListQueryHandler(IDbContext context, IMapper mapper) {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }
      public Task<IGetCountryListQueryResponse> Handle(IGetCountryListQuery request, CancellationToken cancellationToken) {
         var countries = _context
            .Countries
            .Skip(request.Offset).Take(request.Count)
            .Take(request.Count)
            .ProjectTo<CountryListDto>(_mapper.ConfigurationProvider);

         var count = countries.Count();

         return Task.FromResult<IGetCountryListQueryResponse>(new GetCountryListQueryResponse() {
            Count = count,
            HasMore = count == request.Count,
            Offset = request.Offset,
            Result = countries
         });
      }
   }
}
