using Lingvo.Application.Common.Responses;

namespace Lingvo.Application.Lessons;

public record LessonBadRequest : BadRequest
{
    public LessonBadRequest(string message) : base(message)
    {
    }
}
