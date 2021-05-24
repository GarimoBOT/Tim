using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Repos;
using Microsoft.EntityFrameworkCore;

namespace API.ReposImpl
{
    public class AttachmentRepo : IAttachmentRepo
    {
        private readonly DatabaseContext context;
        public AttachmentRepo(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Attachment attachment)
        {
            await context.AddAsync(attachment);
        }

        public void Delete(Attachment attachment)
        {
            context.Remove(attachment);
        }

        public async Task<IEnumerable<Attachment>> GetAllAsync()
        {
            return await context.Attachments.ToListAsync();
        }

        public async Task<Attachment> GetAsync(int attachmentId)
        {
            return await context.Attachments.FindAsync(attachmentId);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}