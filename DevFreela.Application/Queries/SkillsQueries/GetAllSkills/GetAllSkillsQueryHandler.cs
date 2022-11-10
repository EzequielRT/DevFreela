using DevFreela.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.SkillsQueries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllSkills();

            var skillsViewModel = skills
                .Select(x => new SkillViewModel()
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .ToList();

            return skillsViewModel;
        }
    }
}