using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Repos;
using API.Services;
using AutoMapper;

namespace API.ServicesImpl
{
    public class ApplicationService : IApplicationService
    {
        private readonly IMapper mapper;
        private readonly IApplicationRepo applicationRepo;
        private readonly IAccreditationRepo accreditationRepo;
        public ApplicationService(IMapper mapper, IApplicationRepo applicationRepo, IAccreditationRepo accreditationRepo)
        {
            this.accreditationRepo = accreditationRepo;
            this.applicationRepo = applicationRepo;
            this.mapper = mapper;
        }
        public async Task<IAsyncResult> AddAsync(ApplicationToAdd applicationToAdd)
        {
            var application = mapper.Map<Application>(applicationToAdd);

            await applicationRepo.AddAsync(application);

            if (await applicationRepo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Error occured");
        }

        public async Task<IAsyncResult> ApproveAsync(int applicationId)
        {
            var application = await applicationRepo.GetAsync(applicationId);

            if (application == null) throw new Exception("Not found");

            application.Approved = true;

            if (await applicationRepo.SaveAllAsync())
            {
                await accreditationRepo.AddAsync(new Accreditation 
                {
                    UserId = application.UserId,
                    PatternId = application.PatternId,
                    ValidDate = DateTime.Now.AddYears(1)
                });

                if(await accreditationRepo.SaveAllAsync()) return Task.CompletedTask;
            }

            throw new Exception("Error occured");
        }

        public async Task<IAsyncResult> CommentApplicationAsync(int id, CommentToAdd comment)
        {
            var application = await applicationRepo.GetAsync(id);

            if (application == null) throw new Exception("Not found");

            application.AdminComment = comment.Comment;

            if (await applicationRepo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Error occured");

        }

        public async Task<IAsyncResult> DeleteAsync(int applicationId)
        {
            var application = await applicationRepo.GetAsync(applicationId);

            if (application == null) throw new Exception("Not found");

            applicationRepo.Delete(application);

            if (await applicationRepo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Error occured");
        }

        public async Task<IEnumerable<ApplicationToReturn>> GetAllAsync()
        {
            var applications = await applicationRepo.GetAllAsync();

            if (applications == null) throw new Exception("Not found");

            var applicationsToReutrn = mapper.Map<IEnumerable<ApplicationToReturn>>(applications);

            return applicationsToReutrn;
        }

        public async Task<IEnumerable<ApplicationToReturn>> GetAllForUserAsync(int id)
        {
            var applications = await applicationRepo.GetAllForUserAsync(id);

            if (applications == null) throw new Exception("Not found");

            var applicationsToReutrn = mapper.Map<IEnumerable<ApplicationToReturn>>(applications);

            return applicationsToReutrn;
        }

        public async Task<IEnumerable<ApplicationToReturn>> GetAllNonApprovedAsync()
        {
            var applications = await applicationRepo.GetAllNonApprovedAsync();

            if (applications == null) throw new Exception("Not found");

            var applicationsToReutrn = mapper.Map<IEnumerable<ApplicationToReturn>>(applications);

            return applicationsToReutrn;
        }

        public async Task<ApplicationToReturn> GetAsync(int applicationId)
        {
            var application = await applicationRepo.GetAsync(applicationId);

            if (application == null) throw new Exception("Not found");

            var applicationToReturn = mapper.Map<ApplicationToReturn>(application);

            return applicationToReturn;
        }
    }
}