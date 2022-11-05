using System;

namespace DevFreela.Application.Queries.ProjectQueries.GetProjectById
{
    public class ProjectDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
        public string ClientFullName { get; set; }
        public string FreelancerFullName { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}