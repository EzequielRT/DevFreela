using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        public Task<List<Project>> GetAllProjectsAsync();
        public Task<Project> GetProjectByIdAsync(int id);
        public Task AddAsync(Project project);
        public Task<bool> StartAsync(Project project);
        public Task<bool> SaveChangesAsync();
        public Task<bool> AddCommentAsync(ProjectComment projectComment);
    }
}