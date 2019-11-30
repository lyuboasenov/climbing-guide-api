using AutoMapper;
using AutoMapper.QueryableExtensions;
using Climbing.Guide.Api.Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Areas.Queries.GetAreasQuery {
   public class GetAreasQueryHandler : IRequestHandler<IGetAreasQueryRequest, IGetAreasQueryReply> {
      private readonly IRepository _context;
      private readonly IMapper _mapper;

      public GetAreasQueryHandler(IRepository context, IMapper mapper) {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }
      public Task<IGetAreasQueryReply> Handle(IGetAreasQueryRequest request, CancellationToken cancellationToken) {
         var areas = _context
            .Areas
            .Skip(request.Offset).Take(request.Count)
            .Take(request.Count)
            .ProjectTo<AreaDto>(_mapper.ConfigurationProvider);

         var count = areas.Count();

         return Task.FromResult<IGetAreasQueryReply>(new GetAreasQueryReply() {
            Count = count,
            HasMore = count == request.Count,
            Offset = request.Offset,
            Results = areas
         });
      }
   }
}
