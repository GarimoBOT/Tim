using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Services
{
    public interface IAttachmentService
    {
        Task<IAsyncResult> AddAsync(AttachmentToAdd attachmentToAdd);
        Task<IAsyncResult> DeleteAsync(int attachmentId);
        Task<IEnumerable<AttachmentToReturn>> GetAllAsync();
        Task<AttachmentToReturn> GetAsync(int attachmentId);
    }
}