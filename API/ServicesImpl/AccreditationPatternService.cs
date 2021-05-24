using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;
using API.Repos;
using API.Services;
using AutoMapper;

namespace API.ServicesImpl
{
    public class AccreditationPatternService : IAccreditationPatternService
    {
        private readonly IMapper mapper;
        private readonly IAccreditationPatternRepo accreditationPatternRepo;
        public AccreditationPatternService(IMapper mapper, IAccreditationPatternRepo accreditationPatternRepo)
        {
            this.accreditationPatternRepo = accreditationPatternRepo;
            this.mapper = mapper;

        }
        public async Task<IAsyncResult> AddAsync(AccreditationPatternToAdd accreditationPatternToAdd)
        {
            var patternToAdd = mapper.Map<AccreditationPattern>(accreditationPatternToAdd);

            await accreditationPatternRepo.AddAsync(patternToAdd);

            if (await accreditationPatternRepo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Error adding accreditation pattern.");
        }

        public async Task<IAsyncResult> DeleteAsync(int accreditationPatternId)
        {
            var patternToDelete = await accreditationPatternRepo.GetAsync(accreditationPatternId);

            if (patternToDelete == null) throw new Exception("Not found");

            accreditationPatternRepo.Delete(patternToDelete);

            if (await accreditationPatternRepo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Error deleting accreditation pattern.");
        }

        public async Task<IEnumerable<AccreditationPattern>> GetAllAsync()
        {
            var patterns = await accreditationPatternRepo.GetAllAsync();

            if (patterns == null || patterns.Count() == 0) throw new Exception("No patterns");

            return patterns;
        }

        public async Task<AccreditationPattern> GetAsync(int accreditationPatternId)
        {
            var pattern = await accreditationPatternRepo.GetAsync(accreditationPatternId);

            if (pattern == null) throw new Exception("Not found");

            return pattern;
        }
    }
}