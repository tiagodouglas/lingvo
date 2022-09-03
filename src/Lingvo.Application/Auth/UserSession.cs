using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using Lingvo.Domain.Auth;

namespace Lingvo.Application.Auth;

public class UserSession : IUserSession
{
    public Guid UserId { get; private init; }
    public DateTime Now => DateTime.Now;

    public UserSession(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        var nameIdentifier = user?.FindFirst(ClaimTypes.NameIdentifier);

        if (nameIdentifier != null)
        {
            UserId = new Guid(nameIdentifier.Value);
        }
    }
}
