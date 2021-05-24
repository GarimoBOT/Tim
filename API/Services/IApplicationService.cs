using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Services
{
    public interface IApplicationService
    {
         Task<IAsyncResult> AddAsync(ApplicationToAdd applicationToAdd);
         Task<IAsyncResult> ApproveAsync(int applicationId);
         Task<IAsyncResult> DeleteAsync(int applicationId);
         Task<ApplicationToReturn> GetAsync(int applicationId);
         Task<IEnumerable<ApplicationToReturn>> GetAllAsync();
         Task<IEnumerable<ApplicationToReturn>> GetAllNonApprovedAsync();
         Task<IEnumerable<ApplicationToReturn>> GetAllForUserAsync(int id);
         Task<IAsyncResult> CommentApplicationAsync(int id, CommentToAdd commentToAdd);
    }
}