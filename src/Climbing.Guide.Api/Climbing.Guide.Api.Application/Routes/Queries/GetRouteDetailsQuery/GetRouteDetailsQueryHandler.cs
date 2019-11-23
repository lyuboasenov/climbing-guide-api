using AutoMapper;
using AutoMapper.QueryableExtensions;
using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Application.Routes.Common;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Routes.Queries.GetRouteDetailsQuery {
   public class GetRouteDetailsQueryHandler : IRequestHandler<IGetRouteDetailsQuery, IRouteDetailsReply> {
      private readonly IDbContext _context;
      private readonly IMapper _mapper;

      public GetRouteDetailsQueryHandler(IDbContext context, IMapper mapper) {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      }

      public Task<IRouteDetailsReply> Handle(IGetRouteDetailsQuery request, CancellationToken cancellationToken) {
         var querableRoute = _context
            .Routes
            .Where(r => r.Id == request.Id);

         var response = querableRoute.ProjectTo<RouteDetailsReply>(_mapper.ConfigurationProvider).FirstOrDefault();

         if (response != null
            && querableRoute.FirstOrDefault() is Domain.Entities.Route route) {
            response.AreaId = route.Area.Id;
            response.AreaName = route.Area.Name;

            response.CreatedById = route.CreatedBy.Id;
            response.CreatedByName = route.CreatedBy.Name;

            response.UpdatedById = route.UpdatedBy.Id;
            response.UpdatedByName = route.UpdatedBy.Name;

            response.Schema = string.Format(Const.SCHEMA_LOCATION_PATH_FORMAT, (int) request.SchemaSize, route.Area.Id, route.Id);

            response.Topo = route.Topo.Select(p => new Entities.SchemaPoint() { X = p.X, Y = p.Y });
         }

         return Task.FromResult<IRouteDetailsReply>(response);
      }
   }
}
