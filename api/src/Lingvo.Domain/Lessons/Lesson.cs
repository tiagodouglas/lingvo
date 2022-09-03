using System;

namespace Lingvo.Domain.Lessons;

public class Lesson
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LanguageId { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
