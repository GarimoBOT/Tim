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
    public class AccreditationService : IAccreditationService
    {
        private readonly IAccreditationRepo accreditationRepo;
        private readonly IMapper mapper;
        public AccreditationService(IAccreditationRepo accreditationRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.accreditationRepo = accreditationRepo;
        }
        public async Task<IAsyncResult> AddAsync(AccreditationToAdd accreditationToAdd)
        {
            var accToAdd = mapper.Map<Accreditation>(accreditationToAdd);

            await accreditationRepo.AddAsync(accToAdd);

            if (await accreditationRepo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Error adding accreditation.");
        }

        public async Task<IAsyncResult> DeleteAsync(int accreditationId)
        {
            var accToDelete = await accreditationRepo.GetAsync(accreditationId);

            if (accToDelete == null) throw new Exception("Not found");

            accreditationRepo.Delete(accToDelete);

            if (await accreditationRepo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Error deleting accreditation.");
        }

        public async Task<IEnumerable<AccreditationToReturn>> GetAllAsync()
        {
            var accreditations = await accreditationRepo.GetAllAsync();

            if (accreditations == null) throw new Exception("No accs");

            var accrediationsToReturn = mapper.Map<IEnumerable<AccreditationToReturn>>(accreditations);

            return accrediationsToReturn;
        }

        public async Task<IEnumerable<AccreditationToReturn>> GetAllForUserAsync(int id)
        {
            var accreditations = await accreditationRepo.GetAllForUserAsync(id);

            if (accreditations == null) throw new Exception("No accs");

            var accrediationsToReturn = mapper.Map<IEnumerable<AccreditationToReturn>>(accreditations);

            return accrediationsToReturn;
        }

        public async Task<AccreditationToReturn> GetAsync(int accreditationId)
        {
            var accreditation = await accreditationRepo.GetAsync(accreditationId);

            if (accreditation == null) throw new Exception("Not found");

            var accrediationToReturn = mapper.Map<AccreditationToReturn>(accreditation);

            return accrediationToReturn;
        }
    }
}