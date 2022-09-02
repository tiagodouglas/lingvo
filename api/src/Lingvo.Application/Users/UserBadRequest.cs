using Lingvo.Application.Common.Responses;

namespace Lingvo.Application.Users
{
    public record UserBadRequest : BadRequest
    {
        public UserBadRequest(string message) : base(message)
        {
        }
    }
}
