using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Services
{
    public interface IAuthService
    {
        Task<IAsyncResult> RegisterUserAsync(UserToRegister userToRegisterDTO);
        Task<UserToReturn> LoginUserAsync(UserToLogin userToLoginDTO);
    }
}