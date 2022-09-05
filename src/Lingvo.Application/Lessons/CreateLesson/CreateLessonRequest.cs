using MediatR;
using OneOf;
using System;

namespace Lingvo.Application.Lessons.CreateLesson;

public record CreateLessonRequest: IRequest<OneOf<LessonResponse?, LessonBadRequest>>
{
    public string Name { get; set; }
    public Guid LanguageId { get; set; }
}
