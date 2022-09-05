using FluentValidation;

namespace Lingvo.Application.Lessons.CreateLesson;

public class CreateLessonValidator: AbstractValidator<CreateLessonRequest>
{
    public CreateLessonValidator()
    {
        RuleLevelCascadeMode = ClassLevelCascadeMode;

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);

        RuleFor(x => x.LanguageId)
            .NotEmpty()
            .NotNull();
    }
}
