namespace Lingvo.Application.Common.Responses;

public record class BadRequest
{
    public BadRequest(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}

