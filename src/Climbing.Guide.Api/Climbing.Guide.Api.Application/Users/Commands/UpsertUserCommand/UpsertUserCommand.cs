using MediatR;

namespace Climbing.Guide.Api.Application.Users.Commands.UpsertUserCommand {
   public class UpsertUserCommand : IRequest<string> {
      public string Id { get; set; }
      public string Name { get; set; }
   }
}
