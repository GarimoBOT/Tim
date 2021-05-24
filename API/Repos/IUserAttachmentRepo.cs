using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Repos
{
    public interface IUserAttachmentRepo
    {
         Task AddAsync(UserAttachment attachment);
         void Delete(UserAttachment attachment);
         Task<IEnumerable<UserAttachment>> GetAllAsync();
         Task<UserAttachment> GetAsync(int attachmentId);
         Task<bool> SaveAllAsync();
    }
}