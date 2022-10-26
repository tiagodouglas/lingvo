namespace Lingvo.Presentation.Models;

public class Lesson
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public Guid UserId { get; set; }
    public Guid LanguageId { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
