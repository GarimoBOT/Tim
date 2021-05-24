using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.ServicesImpl
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly RoleManager<AppRole> roleManager;
        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<IAsyncResult> DeleteAsync(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            if (user == null) throw new Exception("Not found");

            var result = await userManager.DeleteAsync(user);

            if (!result.Succeeded) throw new Exception("error deleting an user");

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<UserToReturn>> GetAllAdminsAsync()
        {
            var users = await userManager.GetUsersInRoleAsync("Admin");

            if (users == null) throw new Exception("Not found");

            var usersToReturn = mapper.Map<IEnumerable<UserToReturn>>(users);

            return usersToReturn;
        }

        public async Task<IEnumerable<UserToReturn>> GetAllAsync()
        {
            var users = await userManager.Users.ToListAsync();

            if (users == null) throw new Exception("Not found");

            var usersToReturn = mapper.Map<IEnumerable<UserToReturn>>(users);

            int i = 0;

            foreach(var user in usersToReturn)
            {
                var role = await userManager.GetRolesAsync(users[i]);
                user.Role = role[0];
                i++;
            }

            return usersToReturn;
        }

        public async Task<IEnumerable<UserToReturn>> GetAllUsersAsync()
        {
            var users = await userManager.GetUsersInRoleAsync("User");

            if (users == null) throw new Exception("Not found");

            var usersToReturn = mapper.Map<IEnumerable<UserToReturn>>(users);

            return usersToReturn;
        }

        public async Task<UserToReturn> GetAsync(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            
            var role = await userManager.GetRolesAsync(user);

            if (user == null) throw new Exception("Not found");

            var userToReturn = mapper.Map<UserToReturn>(user);

            userToReturn.Role = role[0];

            return userToReturn;
        }
    }
}