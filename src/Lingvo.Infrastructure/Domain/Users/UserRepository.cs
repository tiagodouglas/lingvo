using Dapper;
using System;
using System.Threading.Tasks;
using Lingvo.Domain.Common;
using Lingvo.Domain.Users;

namespace Lingvo.Infrastructure.Domain.Users;

public class UserRepository: IUserRepository
{
    private readonly IDatabaseConnection _db;

    public UserRepository(IUnitOfWork unitOfWork)
    {
        _db = unitOfWork.Get();
    }

    public async Task CreateUser(User user)
    {
        var sql = @"
                INSERT INTO Public.""Users"" (""Id"", ""Name"", ""Email"", ""Password"", ""DateCreated"")
	                VALUES (@Id, @Name, @Email, @Password, @DateCreated)
            ";

        await _db.Connection.QueryAsync(
            sql: sql,
            param: new
            {
                Id = user.Id,
                user.Name,
                user.Email,
                user.Password,
                user.DateCreated
            },
            transaction: _db.Transaction
            );
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _db.Connection.QueryFirstOrDefaultAsync<User>(
            sql: @"
                 	SELECT ""Id"",
                           ""Email"",
						   ""Password"",
                           ""Name""
					FROM Public.""Users""
					WHERE ""Email"" = @Email
                ",
            param: new
            {
                Email = email.ToLower(),
            },
            transaction: _db.Transaction
            );
    }

    public async Task<bool> VerifyIfUserExists(string email)
    {
        return await _db.Connection.QueryFirstOrDefaultAsync<bool>(
            sql: @"
                  SELECT 1
                    FROM Public.""Users""
                    WHERE ""Email"" = @Email
                    LIMIT 1
                ",
            param: new
            {
                Email = email,
            },
            transaction: _db.Transaction
            );
    }
}
