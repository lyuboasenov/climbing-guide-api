using FluentValidation;

namespace Climbing.Guide.Api.Application.Areas.Commands.UpsertAreaCommand {
   public class UpsertAreaCommandValidator : AbstractValidator<UpsertAreaCommand> {
      public UpsertAreaCommandValidator() {
         RuleFor(x => x.Name).MaximumLength(128).NotEmpty();
      }
   }
}
