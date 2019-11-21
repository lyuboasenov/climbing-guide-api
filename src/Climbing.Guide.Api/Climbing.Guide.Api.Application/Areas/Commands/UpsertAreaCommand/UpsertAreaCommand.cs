using MediatR;

namespace Climbing.Guide.Api.Application.Areas.Commands.UpsertAreaCommand {
   public class UpsertAreaCommand : IRequest<string> {
      public string Id { get; set; }
      public string Name { get; set; }
   }
}
