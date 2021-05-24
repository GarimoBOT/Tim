using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Repos;
using Microsoft.EntityFrameworkCore;

namespace API.ReposImpl
{
    public class ApplicationRepo : IApplicationRepo
    {
        private readonly DatabaseContext context;
        public ApplicationRepo(DatabaseContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Application application)
        {
            await context.AddAsync(application);
        }

        public void Delete(Application application)
        {
            context.Remove(application);
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await context.Application
                .Include(x => x.Pattern)
                .Include(x => x.User)
                .Include(x =>x.UserAttachments).ToListAsync();
        }

        public async Task<IEnumerable<Application>> GetAllForUserAsync(int id)
        {
            return await context.Application.Where(x => x.UserId == id)
                .Include(x => x.Pattern)
                .Include(x => x.User)
                .Include(x =>x.UserAttachments).ToListAsync();
        }

        public async Task<IEnumerable<Application>> GetAllNonApprovedAsync()
        {
            return await context.Application.Where(x => x.Approved == false)
                .Include(x => x.Pattern)
                .Include(x => x.User)
                .Include(x =>x.UserAttachments).ToListAsync();
        }

        public async Task<Application> GetAsync(int applicationId)
        {
            return await context.Application
                .Include(x => x.Pattern)
                .Include(x => x.UserAttachments)
                .Include(x => x.User).FirstOrDefaultAsync(x => x.Id == applicationId);

        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}