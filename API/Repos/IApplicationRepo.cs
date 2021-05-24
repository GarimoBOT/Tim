using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Repos
{
    public interface IApplicationRepo
    {
        Task AddAsync(Application application);
        void Delete(Application application);
        Task<Application> GetAsync(int applicationId);
        Task<IEnumerable<Application>> GetAllAsync();
        Task<IEnumerable<Application>> GetAllNonApprovedAsync();
        Task<IEnumerable<Application>> GetAllForUserAsync(int id);
        Task<bool> SaveAllAsync();
    }
}