using Lingvo.Application.Lessons.CreateLesson;
using Lingvo.Domain.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lingvo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserSession _session;

        public LessonController(IMediator mediator, IUserSession session)
        {
            _mediator = mediator;
            _session = session;
        }

        /// <summary>
        /// Create a new lesson
        /// </summary>
        /// <param name="request">The lesson information</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateLesson([FromBody] CreateLessonRequest request)
        {
            var created = await _mediator.Send(request);

            return created.Match<IActionResult>(
               valid => CreatedAtAction(nameof(CreateLesson), new { id = valid?.Id }, valid),
               badRequest => BadRequest(badRequest)
               );
        }
    }
}
