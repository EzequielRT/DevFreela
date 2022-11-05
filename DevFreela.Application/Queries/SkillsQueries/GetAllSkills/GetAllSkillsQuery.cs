using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.SkillsQueries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}