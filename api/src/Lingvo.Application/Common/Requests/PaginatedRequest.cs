namespace Lingvo.Application.Common.Requests;

public record PaginatedRequest
{
    public int Page { get; init; } = 1;
    public int Rows { get; init; } = 15;
}
