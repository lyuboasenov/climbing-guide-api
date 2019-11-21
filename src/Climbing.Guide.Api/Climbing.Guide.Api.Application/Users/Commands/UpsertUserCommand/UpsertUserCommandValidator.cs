using FluentValidation;

namespace Climbing.Guide.Api.Application.Users.Commands.UpsertUserCommand {
   public class UpsertUserCommandValidator : AbstractValidator<UpsertUserCommand> {
      protected UpsertUserCommandValidator() {
         RuleFor(x => x.Name).MaximumLength(128).NotEmpty();
      }
   }
}
