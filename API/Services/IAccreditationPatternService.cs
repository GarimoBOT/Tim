using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Services
{
    public interface IAccreditationPatternService
    {
         Task<IAsyncResult> AddAsync(AccreditationPatternToAdd accreditationPatternToAdd);
         Task<IAsyncResult> DeleteAsync(int accreditationPatternId);
         Task<IEnumerable<AccreditationPattern>> GetAllAsync();
         Task<AccreditationPattern> GetAsync(int accreditationPatternId);
    }
}