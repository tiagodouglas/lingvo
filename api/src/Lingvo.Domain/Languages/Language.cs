using MassTransit;
using System;

namespace Lingvo.Domain.Languages;

public class Language
{
    public Guid Id { get; set; } = NewId.NextSequentialGuid();
    public int Name { get; set; }
}
