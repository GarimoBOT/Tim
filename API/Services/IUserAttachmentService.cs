using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Services
{
    public interface IUserAttachmentService
    {
        Task<IAsyncResult> AddAsync(UserAttachmentToAdd attachmentToAdd);
        Task<IAsyncResult> DeleteAsync(int attachmentId);
        Task<IEnumerable<UserAttachmentToReturn>> GetAllAsync();
        Task<UserAttachmentToReturn> GetAsync(int attachmentId);
    }
}