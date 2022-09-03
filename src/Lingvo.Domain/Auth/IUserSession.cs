using System;

namespace Lingvo.Domain.Auth;

public interface IUserSession
{
    public Guid UserId { get; }

    public DateTime Now { get; }
}
