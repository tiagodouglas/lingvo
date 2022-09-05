using AutoMapper;
using Lingvo.Domain.Auth;
using Lingvo.Domain.Common;
using Lingvo.Domain.Lessons;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lingvo.Application.Lessons.CreateLesson
{
    public class CreateLessonHandler : IRequestHandler<CreateLessonRequest, OneOf<LessonResponse?, LessonBadRequest>>
    {
        private readonly IDatabaseConnection _db;
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserSession _userSession;

        public CreateLessonHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILessonRepository lessonRepository,
            IUserSession userSession)
        {
            _db = unitOfWork.Get();
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _userSession = userSession;
        }

        public async Task<OneOf<LessonResponse?, LessonBadRequest>> Handle(CreateLessonRequest request, CancellationToken cancellationToken)
        {
            var created = _mapper.Map<Lesson>(request);

            created.DateCreated = DateTime.UtcNow;
            created.UserId = _userSession.UserId;

            await _lessonRepository.CreateLesson(created);

            _db.Commit();

            return _mapper.Map<LessonResponse?>(created);
        }
    }
}
