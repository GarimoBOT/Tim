using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Repos;
using Microsoft.EntityFrameworkCore;

namespace API.ReposImpl
{
    public class UserAttachmentRepo : IUserAttachmentRepo
    {
        private readonly DatabaseContext context;
        public UserAttachmentRepo(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(UserAttachment attachment)
        {
            await context.AddAsync(attachment);
        }

        public void Delete(UserAttachment attachment)
        {
            context.Remove(attachment);
        }

        public async Task<IEnumerable<UserAttachment>> GetAllAsync()
        {
            return await context.UserAttachment.ToListAsync();
        }

        public async Task<UserAttachment> GetAsync(int attachmentId)
        {
            return await context.UserAttachment.FindAsync(attachmentId);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}