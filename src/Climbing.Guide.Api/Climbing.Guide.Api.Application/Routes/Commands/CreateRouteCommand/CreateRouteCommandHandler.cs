using Climbing.Guide.Api.Application.Exceptions;
using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Application.Routes.Common;
using Climbing.Guide.Api.Domain.Common;
using Climbing.Guide.Api.Domain.Entities;
using Climbing.Guide.Api.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Routes.Commands.CreateRouteCommand {
   public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, string> {
      private readonly IDbContext _dbContext;
      private readonly IValueFactory _valueFactory;
      private readonly IFsContext _fsContext;
      private readonly IImageUtil _imageUtil;
      private readonly ICurrentUser _currentUser;

      public CreateRouteCommandHandler(IDbContext dbContext,
         IFsContext fsContext,
         IImageUtil imageUtil,
         IValueFactory valueFactory,
         ICurrentUser currentUser) {
         _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
         _valueFactory = valueFactory ?? throw new ArgumentNullException(nameof(valueFactory));
         _fsContext = fsContext ?? throw new ArgumentNullException(nameof(fsContext));
         _imageUtil = imageUtil ?? throw new ArgumentNullException(nameof(imageUtil));
         _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
      }

      public async Task<string> Handle(CreateRouteCommand request, CancellationToken cancellationToken) {
         var area = await _dbContext.Areas.FindAsync(request.AreaId) ?? throw new NotFoundException(typeof(Area), request.AreaId);
         var user = await _dbContext.Users.FindAsync(_currentUser.Id) ?? throw new NotFoundException(typeof(User), _currentUser.Id);

         var route = new Route() {
            Id = _valueFactory.CreateId(),
            Area = area,
            Type = (Domain.Entities.RouteType) request.Type,
            Name = request.Name,
            Info = request.Info,
            Approach = request.Approach,
            History = request.History,
            Difficulty = request.Difficulty,
            Rating = request.Rating,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Length = request.Length,
            CreatedBy = user,
            CreatedOn = _valueFactory.GetCurrentDateTime(),
            Status = EntityStatus.Active
         };

         foreach (var point in request.Topo) {
            route.Topo.Add(new TopoPoint(point.X, point.Y));
         }

         _dbContext.Routes.Add(route);

         await _dbContext.SaveChangesAsync(cancellationToken);

         foreach (var thumbSize in Const.SCHEMA_SIZES) {
            await _fsContext.WriteFileAsync(
               string.Format(Const.SCHEMA_LOCATION_PATH_FORMAT, thumbSize, route.Area.Id, route.Id),
               await _imageUtil.GetThumbAsync(request.Schema, thumbSize));
         }

         return route.Id;
      }
   }
}
