using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Repos;
using Microsoft.EntityFrameworkCore;

namespace API.ReposImpl
{
    public class AccreditationRepo : IAccreditationRepo
    {
        private readonly DatabaseContext context;
        public AccreditationRepo(DatabaseContext context)
        {
            this.context = context;

        }
        public async Task AddAsync(Accreditation accreditation)
        {
            await context.AddAsync(accreditation);
        }

        public void Delete(Accreditation accreditation)
        {
            context.Remove(accreditation);
        }

        public async Task<IEnumerable<Accreditation>> GetAllAsync()
        {
            return await context.Accreditation
                .Include(x => x.User)
                .Include(x => x.Pattern)
                .ToListAsync(); 
        }

        public async Task<IEnumerable<Accreditation>> GetAllForUserAsync(int id)
        {
            return await context.Accreditation.Where(x => x.UserId == id)
                .Include(x => x.User)
                .Include(x => x.Pattern)
                .ToListAsync();
        }

        public async Task<Accreditation> GetAsync(int accreditationId)
        {
            return await context.Accreditation
                .Include(x => x.User)
                .Include(x => x.Pattern)
                .FirstOrDefaultAsync(x => x.Id == accreditationId);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}