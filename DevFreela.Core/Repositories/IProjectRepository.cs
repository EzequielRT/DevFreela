﻿using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        public Task<List<Project>> GetAllProjects();
        public Task<Project> GetProjectById(int id);
    }
}