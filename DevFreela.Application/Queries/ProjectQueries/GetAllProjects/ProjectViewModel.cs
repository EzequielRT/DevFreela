using System;

namespace DevFreela.Application.Queries.ProjectQueries.GetAllProjects
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}