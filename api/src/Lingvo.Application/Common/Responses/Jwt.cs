using System;

namespace Lingvo.Application.Common.Responses;

public record class Jwt
{
    public string Token { get; init; } = null!;
    public DateTime ExpDate { get; init; }
}
