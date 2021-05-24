using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.ServicesImpl
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(IMapper mapper, UserManager<AppUser> manager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = manager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<UserToReturn> LoginUserAsync(UserToLogin userToLoginDTO)
        {
            userToLoginDTO.UserName = userToLoginDTO.UserName.ToLower();
            
            var userFromRepo = await _userManager.FindByNameAsync(userToLoginDTO.UserName);
            var roles = await _userManager.GetRolesAsync(userFromRepo);

            if(userFromRepo == null)
                throw new Exception("Wrong credentials.");

            var result = await _signInManager
                .CheckPasswordSignInAsync(userFromRepo, userToLoginDTO.Password, false);
            
            if(!result.Succeeded) throw new Exception("Error occurred");

            var userToReturn = _mapper.Map<UserToReturn>(userFromRepo);

            userToReturn.Role = roles[0];
            userToReturn.Token = await _tokenService.CreateTokenAsync(userFromRepo);

            return userToReturn;
        }
        public async Task<IAsyncResult> RegisterUserAsync(UserToRegister userToRegisterDTO)
        {
            userToRegisterDTO.UserName = userToRegisterDTO.UserName.ToLower();
            userToRegisterDTO.Name = userToRegisterDTO.Name.ToLower();
            userToRegisterDTO.Surname = userToRegisterDTO.Surname.ToLower();
            userToRegisterDTO.Email = userToRegisterDTO.Email.ToLower();

            if(await _userManager.FindByNameAsync(userToRegisterDTO.UserName)!=null)
                throw new Exception("Username is already taken.");

            var userToCreate = _mapper.Map<AppUser>(userToRegisterDTO);

            if(userToRegisterDTO.Role == "Admin" || userToRegisterDTO.Role == "User")
            {
                var result = await _userManager.CreateAsync(userToCreate, userToRegisterDTO.Password);

                await _userManager.AddToRoleAsync(userToCreate, userToRegisterDTO.Role);

                if(!result.Succeeded) throw new Exception(result.Errors.ToString());

                return Task.CompletedTask;
            }

            throw new Exception("Role doesn't exist");

        }
    }
}