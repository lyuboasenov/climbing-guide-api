using AutoMapper;
using AutoMapper.QueryableExtensions;
using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Application.Routes.Common;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteListQuery {
   public class GetRouteListQueryHandler : IRequestHandler<GetRouteListQuery, RouteListResponse> {
      private readonly IDbContext _context;
      private readonly IMapper _mapper;

      public GetRouteListQueryHandler(IDbContext context, IMapper mapper) {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public Task<RouteListResponse> Handle(GetRouteListQuery request, CancellationToken cancellationToken) {
         var routes = _context
            .Routes
            .Where(r => r.Status == Domain.Common.EntityStatus.Active &&
               (r.Name.Contains(request.Filter) || r.Info.Contains(request.Filter) || r.History.Contains(request.Filter)))
            .OrderBy(r => r.Difficulty)
            .ThenBy(r => r.CreatedOn)
            .Skip(request.Offset).Take(request.Count)
            .Take(request.Count)
            .ProjectTo<RouteListDto>(_mapper.ConfigurationProvider);

         foreach(var route in routes) {
            route.Schema = string.Format(Const.SCHEMA_LOCATION_PATH_FORMAT, (int) request.SchemaSize, route.AreaId, route.Id);
         }

         return Task.FromResult(new RouteListResponse() {
            Offset = request.Offset,
            Count = request.Count,
            Filter = request.Filter,
            HasMore = request.Count == routes.Count(),
            RouteList = routes
         });
      }
   }
}
