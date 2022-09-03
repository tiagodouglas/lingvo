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
                INSERT INTO [dbo].[Users] ([Id], [Name], [Email], [Password], [DateCreated])
	                VALUES (@Id, @Name, @Email, @Password, @DateCreated)
            ";

        await _db.Connection.QueryAsync(
            sql: sql,
            param: new
            {
                Id = user.Id.ToString(),
                user.Name,
                user.Email,
                user.Password,
                DateCreated = DateTime.Now
            },
            transaction: _db.Transaction
            );
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _db.Connection.QueryFirstOrDefaultAsync<User>(
            sql: @"
                 	SELECT  [Id],
                        [Email],
						[Password]
					FROM [dbo].[Users]
					WHERE [Email] = @Email
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
                  SELECT TOP 1 1
                    FROM [dbo].[Users] 
                    WHERE [Email] = @Email
                ",
            param: new
            {
                Email = email,
            },
            transaction: _db.Transaction
            );
    }
}
