using Dapper;
using Lingvo.Domain.Common;
using Lingvo.Domain.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lingvo.Infrastructure.Domain.Languages;

public class LanguageRepository: ILanguageRepository
{
    private readonly IDatabaseConnection _db;

    public LanguageRepository(IUnitOfWork unitOfWork)
    {
        _db = unitOfWork.Get();
    }

    public async Task<IEnumerable<Language>> GetLanguages()
    {
        var sql = @"          
            SELECT  ""Id"",
                    ""Name""                
                Public.""Languages"" 
            ";

        return await _db.Connection.QueryAsync<Language>(
            sql: sql,
            transaction: _db.Transaction
            );
    }
}
