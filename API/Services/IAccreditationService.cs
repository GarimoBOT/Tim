using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Services
{
    public interface IAccreditationService
    {
         Task<IAsyncResult> AddAsync(AccreditationToAdd accreditationToAdd);
         Task<IAsyncResult> DeleteAsync(int accreditationId);
         Task<AccreditationToReturn> GetAsync(int accreditationId);
         Task<IEnumerable<AccreditationToReturn>> GetAllAsync();
         Task<IEnumerable<AccreditationToReturn>> GetAllForUserAsync(int id);
    }
}