using System;

namespace Lingvo.Domain.Texts
{
    public class Text
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AudioUri { get; set; }
        public string Body { get; set; }
        public Guid LanguageId { get; set; }
        public Guid LessonId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
