using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Domain.Entities;
using Climbing.Guide.Api.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Areas.Commands.UpsertAreaCommand {
   public class UpsertAreaCommandHandler : IRequestHandler<UpsertAreaCommand, string> {
      private readonly IDbContext _context;
      private readonly IValueFactory _valueFactory;

      public UpsertAreaCommandHandler(IDbContext context, IValueFactory valueFactory) {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _valueFactory = valueFactory;
      }

      public async Task<string> Handle(UpsertAreaCommand request, CancellationToken cancellationToken) {
         Area area = null;

         if (request.Id is string id) {
            area = await _context.Areas.FindAsync(id);
         }

         area ??= new AreasContainer() {
            Id = _valueFactory.CreateId(),
            Name = request.Name
         };

         _context.Areas.Add(area);

         await _context.SaveChangesAsync(cancellationToken);

         return area.Id;
      }
   }
}
