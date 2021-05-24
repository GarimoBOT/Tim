using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Services
{
    public interface IUserService
    {
         Task<UserToReturn> GetAsync(int id);
         Task<IEnumerable<UserToReturn>> GetAllAsync();
         Task<IEnumerable<UserToReturn>> GetAllUsersAsync();
         Task<IEnumerable<UserToReturn>> GetAllAdminsAsync();
         Task<IAsyncResult> DeleteAsync(int id);
    }
}