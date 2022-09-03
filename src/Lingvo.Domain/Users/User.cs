using MassTransit;
using System;

namespace Lingvo.Domain.Users;

public class User 
{
    public Guid Id { get; set; } = NewId.NextSequentialGuid();
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int? AvatarId { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
