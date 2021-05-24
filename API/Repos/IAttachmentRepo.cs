using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Repos
{
    public interface IAttachmentRepo
    {
         Task AddAsync(Attachment attachment);
         void Delete(Attachment attachment);
         Task<IEnumerable<Attachment>> GetAllAsync();
         Task<Attachment> GetAsync(int attachmentId);
         Task<bool> SaveAllAsync();
    }
}