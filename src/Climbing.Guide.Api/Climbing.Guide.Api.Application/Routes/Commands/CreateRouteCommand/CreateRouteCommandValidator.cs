using FluentValidation;

namespace Climbing.Guide.Api.Application.Routes.Commands.CreateRouteCommand {
   public class CreateRouteCommandValidator : AbstractValidator<ICreateRouteCommand> {
      public CreateRouteCommandValidator() {
         RuleFor(x => x.Name).MaximumLength(128).NotEmpty();
         RuleFor(x => x.AreaId).NotEmpty();
         RuleFor(x => x.Difficulty).GreaterThan(0).NotEmpty();
         RuleFor(x => (int) x.Length).GreaterThan(0);
         RuleFor(x => x.Schema).NotEmpty();
         RuleFor(x => x.Topo).NotEmpty();
      }
   }
}
