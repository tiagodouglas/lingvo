using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lingvo.Application.Lessons.GetLesson;

public record GetLessonRequest : IRequest<OneOf<List<LessonResponse?>, LessonBadRequest>>
{
}
