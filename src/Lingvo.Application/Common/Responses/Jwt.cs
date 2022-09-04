using System;

namespace Lingvo.Application.Common.Responses;

public record class Jwt
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Token { get; init; } = null!;
    public DateTime ExpDate { get; init; }
}
