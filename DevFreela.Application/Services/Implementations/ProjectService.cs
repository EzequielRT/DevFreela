using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        public Task<int> Create(NewProjectInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public Task CreateComment(CreateCommentInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Finish(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectViewModel>> GetAll(string query)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDetailsViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Start(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateProjectInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}