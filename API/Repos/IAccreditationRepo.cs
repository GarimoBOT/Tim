using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Repos
{
    public interface IAccreditationRepo
    {
        Task AddAsync(Accreditation accreditation);
        void Delete(Accreditation accreditation);
        Task<IEnumerable<Accreditation>> GetAllAsync();
        Task<IEnumerable<Accreditation>> GetAllForUserAsync(int id);
        Task<Accreditation> GetAsync(int accreditationId);
        Task<bool> SaveAllAsync();
    }
}