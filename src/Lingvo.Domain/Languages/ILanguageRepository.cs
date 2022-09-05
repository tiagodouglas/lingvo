using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lingvo.Domain.Languages
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetLanguages();
    }
}
