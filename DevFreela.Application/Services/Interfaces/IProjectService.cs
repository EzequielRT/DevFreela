using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectViewModel>> GetAll(string query);
        Task<ProjectDetailsViewModel> GetById(int id);
        Task<int> Create(NewProjectInputModel inputModel);
        Task<bool> Update(UpdateProjectInputModel inputModel);
        Task<bool> Delete(int id);
        Task<bool> CreateComment(CreateCommentInputModel inputModel);
        Task<bool> Start(int id);
        Task<bool> Finish(int id);
    }
}