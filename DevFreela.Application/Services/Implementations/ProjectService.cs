using Dapper;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<int> Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);

            _dbContext.Projects.Add(project);

            await _dbContext.SaveChangesAsync();

            return project.Id;
        }

        public async Task<bool> CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.ProjectComments.Add(comment);

            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return false;

            project.Cancel();

            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return false;

            project.Cancel();

            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<ProjectViewModel>> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = _dbContext.Projects
                .Select(x => new ProjectViewModel() 
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreatedAt = x.CreatedAt                    
                })
                .ToList();

            return projectsViewModel;
        }

        public async Task<ProjectDetailsViewModel> GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);

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

        public async Task<bool> Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return false;

            project.Start();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();

                var sql = "UPDATE Project SET Status = @Status, StartedAt = @StartedAt WHERE Id = @Id";

                var result = await sqlConnection.ExecuteAsync(sql,
                           new
                           {
                               Id = id,
                               Status = project.Status,
                               StartedAt = project.StartedAt
                           });

                return result > 0;
            }

            //var result = await _dbContext.SaveChangesAsync();

            //return result > 0;
        }

        public async Task<bool> Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            if (project == null)
                return false;

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);

            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}