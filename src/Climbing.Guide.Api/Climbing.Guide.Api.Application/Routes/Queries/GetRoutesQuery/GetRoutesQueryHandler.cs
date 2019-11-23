using AutoMapper;
using AutoMapper.QueryableExtensions;
using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Application.Routes.Common;
using Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery;
using Climbing.Guide.Api.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRoutesQuery {
   public class GetRoutesQueryHandler : IRequestHandler<IGetRoutesQuery, IGetRoutesReply> {
      private readonly IDbContext _context;
      private readonly IMapper _mapper;

      public GetRoutesQueryHandler(IDbContext context, IMapper mapper) {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public Task<IGetRoutesReply> Handle(IGetRoutesQuery request, CancellationToken cancellationToken) {
         var routes = _context
            .Routes
            .Where(r => r.Status == EntityStatus.Active &&
               (r.Name.Contains(request.Filter) || r.Info.Contains(request.Filter) || r.History.Contains(request.Filter)))
            .OrderBy(r => r.Difficulty)
            .ThenBy(r => r.CreatedOn)
            .Skip(request.Offset).Take(request.Count)
            .Take(request.Count)
            .ProjectTo<RouteDto>(_mapper.ConfigurationProvider);

         foreach (var route in routes) {
            route.Schema = string.Format(Const.SCHEMA_LOCATION_PATH_FORMAT, (int) request.SchemaSize, route.AreaId, route.Id);
         }

         var count = routes.Count();

         return Task.FromResult<IGetRoutesReply>(new GetRoutesReply() {
            Offset = request.Offset,
            Count = count,
            Filter = request.Filter,
            HasMore = request.Count == count,
            Results = routes
         });
      }
   }
}
