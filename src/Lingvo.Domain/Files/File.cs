using MassTransit;
using System;

namespace Lingvo.Domain.Files;

public class File
{
    public Guid Id { get; set; } = NewId.NextSequentialGuid();
    public string Name { get; set; }
    public string Path { get; set; }
    public string Url { get; set; }
}
