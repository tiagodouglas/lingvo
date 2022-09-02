using FluentValidation;

namespace Lingvo.Application.Users.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleLevelCascadeMode = ClassLevelCascadeMode;

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.Email)
              .NotEmpty()
              .NotNull()
              .EmailAddress()
              .MaximumLength(50);

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

        }
    }
}
