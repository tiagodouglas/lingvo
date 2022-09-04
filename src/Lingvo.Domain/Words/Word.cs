using System;

namespace Lingvo.Domain.Words;

public class Word
{
    public int Id { get; set; }
    public string Original { get; set; }
    public string Translated { get; set; }
    public Guid TextId { get; set; }
    public Guid UserId { get; set; }
    public Guid LanguageId { get; set; }
    public int StatusId { get; set; }
    public bool Removed { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
