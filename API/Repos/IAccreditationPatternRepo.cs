using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Repos
{
    public interface IAccreditationPatternRepo
    {
         Task AddAsync(AccreditationPattern attachment);
         void Delete(AccreditationPattern attachment);
         Task<IEnumerable<AccreditationPattern>> GetAllAsync();
         Task<AccreditationPattern> GetAsync(int attachmentId);
         Task<bool> SaveAllAsync();
    }
}