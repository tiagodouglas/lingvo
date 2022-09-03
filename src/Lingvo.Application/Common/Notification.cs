using MediatR;

namespace Lingvo.Application.Common;

public class Notification: INotification
{
    public Notification(string message)
    {
        Message = message;
    }
    public string Message { get; }
}
