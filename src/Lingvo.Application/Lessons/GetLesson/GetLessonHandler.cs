using AutoMapper;
using Lingvo.Application.Lessons.CreateLesson;
using Lingvo.Domain.Auth;
using Lingvo.Domain.Common;
using Lingvo.Domain.Lessons;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lingvo.Application.Lessons.GetLesson
{
    public class GetLessonHandler : IRequestHandler<GetLessonRequest, OneOf<List<LessonResponse?>, LessonBadRequest>>
    {
        private readonly IDatabaseConnection _db;
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserSession _userSession;
        private readonly IMapper _mapper;

        public GetLessonHandler(
            IUnitOfWork uow,
            ILessonRepository lessonRepository,
            IUserSession userSession,
            IMapper mapper)
        {
            _db = uow.Get();
            _lessonRepository = lessonRepository;
            _userSession = userSession;
            _mapper = mapper;
        }


        public async Task<OneOf<List<LessonResponse?>, LessonBadRequest>> Handle(GetLessonRequest request, CancellationToken cancellationToken)
        {
            var lessons = await _lessonRepository.GetLessonsByUserId(_userSession.UserId);
            var result = _mapper.Map<List<LessonResponse?>>(lessons);

            return result;
        }
    }
}
