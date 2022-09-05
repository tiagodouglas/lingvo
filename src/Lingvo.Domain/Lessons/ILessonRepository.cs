using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lingvo.Domain.Lessons;

public interface ILessonRepository
{
    Task CreateLesson(Lesson lesson);
    Task<IEnumerable<Lesson>> GetLessonsByUserId(Guid userId);
    Task<IEnumerable<Lesson>> GetLessonsById(Guid lessonId);
    Task UpdateLessonName(Lesson lesson);
    Task DeleteLesson(Guid lessonId);
}
