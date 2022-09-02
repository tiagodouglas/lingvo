using System;

namespace Lingvo.Application.Users
{
    public record UserResponse
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
    }
}
