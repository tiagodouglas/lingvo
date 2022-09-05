using Dapper;
using Lingvo.Domain.Common;
using Lingvo.Domain.Lessons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lingvo.Infrastructure.Domain.Lessons;

public class LessonRepository: ILessonRepository
{
    private readonly IDatabaseConnection _db;

    public LessonRepository(IUnitOfWork unitOfWork)
    {
        _db = unitOfWork.Get();
    }

    public async Task CreateLesson(Lesson lesson)
    {
        var sql = @"
                INSERT INTO Public.""Lessons"" 
                    (""Id"", ""Name"", ""UserId"", ""LanguageId"", ""DateCreated"", ""DateUpdated"")
	                VALUES (@Id, @Name, @UserId, @languageId, @DateCreated, @DateUpdated)
            ";

        await _db.Connection.QueryAsync(
            sql: sql,
            param: new
            {
                Id = lesson.Id,
                Name = lesson.Name,
                UserId = lesson.UserId,
                LanguageId = lesson.LanguageId,
                DateCreated = lesson.DateCreated,
                DateUpdated = lesson.DateUpdated             
            },
            transaction: _db.Transaction
            );
    }

    public async Task<IEnumerable<Lesson>> GetLessonsByUserId(Guid userId)
    {
        var sql = @"          
            SELECT  ""Id"",
                    ""Name"",
                    ""UserId"",
                    ""LanguageId"",
                    ""DateCreated"",
                    ""DateUpdated""
                Public.""Lessons"" 
                WHERE ""UserId"" = @UserId
            ";

        return await _db.Connection.QueryAsync<Lesson>(
            sql: sql,
            param: new
            {
                UserId = userId,
            },
            transaction: _db.Transaction
            );
    }

    public async Task<IEnumerable<Lesson>> GetLessonsById(Guid lessonId)
    {
        var sql = @"          
            SELECT  ""Id"",
                    ""Name"",
                    ""UserId"",
                    ""LanguageId"",
                    ""DateCreated"",
                    ""DateUpdated""
                Public.""Lessons"" 
                WHERE ""Id"" = @Id
            ";

        return await _db.Connection.QueryAsync<Lesson>(
            sql: sql,
            param: new
            {
                Id = lessonId,
            },
            transaction: _db.Transaction
            );
    }

    public async Task UpdateLessonName(Lesson lesson)
    {
        var sql = @"          
            UPDATE Public.""Lessons""
                SET ""Name"",
                    ""DateUpdated""
            WHERE ""Id"" = @Id
            ";

        await _db.Connection.QueryAsync(
            sql: sql,
            param: new
            {
                Name = lesson.Name,
                DateUpdated = lesson.DateUpdated,
                Id = lesson.Id
            },
            transaction: _db.Transaction
            );
    }

    public async Task DeleteLesson(Guid lessonId)
    {
        var sql = @"          
            DELTE FROM Public.""Lessons""
            WHERE ""Id"" = @Id
            ";
        await _db.Connection.QueryAsync(
            sql: sql,
            param: new
            {
                Id = lessonId
            },
            transaction: _db.Transaction
            );
    }
}
