using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillViewModel>> GetAll()
        {
            var skills = _dbContext.Skills;

            if (skills == null)
                return null;

            var skillsViewModels = skills
                .Select(s => new SkillViewModel()
                {
                    Id = s.Id,
                    Description = s.Description,
                })
                .ToList();

            return skillsViewModels;
        }
    }
}