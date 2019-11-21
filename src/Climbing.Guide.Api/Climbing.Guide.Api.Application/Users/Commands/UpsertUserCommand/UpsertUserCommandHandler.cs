using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Domain.Entities;
using Climbing.Guide.Api.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Users.Commands.UpsertUserCommand {
   public class UpsertUserCommandHandler : IRequestHandler<UpsertUserCommand, string> {
      private readonly IDbContext _context;
      private readonly IValueFactory _valueFactory;

      public UpsertUserCommandHandler(IDbContext context, IValueFactory valueFactory) {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _valueFactory = valueFactory;
      }

      public async Task<string> Handle(UpsertUserCommand request, CancellationToken cancellationToken) {
         User user = null;

         if (request.Id is string id) {
            user = await _context.Users.FindAsync(id);
         }

         user ??= new User() {
            Id = _valueFactory.CreateId(),
            Name = request.Name
         };

         _context.Users.Add(user);

         await _context.SaveChangesAsync(cancellationToken);

         return user.Id;
      }
   }
}
