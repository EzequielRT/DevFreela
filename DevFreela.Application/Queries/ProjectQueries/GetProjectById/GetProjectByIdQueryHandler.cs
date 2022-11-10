using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.ProjectQueries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectById(request.Id);

            if (project == null)
                return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                ClientFullName = project.Client.FullName,
                FreelancerFullName = project.Freelancer.FullName,
                TotalCost = project.TotalCost,
                StartedAt = project.StartedAt,
                FinishedAt = project.FinishedAt
            };

            return projectDetailsViewModel;
        }
    }
}