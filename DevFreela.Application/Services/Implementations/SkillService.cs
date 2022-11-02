using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<SkillViewModel>> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();

                var sql = "SELECT Id, Description FROM Skill";

                var skills = await sqlConnection.QueryAsync<SkillViewModel>(sql);

                return skills.ToList();
            }

            //var skills = _dbContext.Skills;

            //var skillsViewModels = skills
            //    .Select(s => new SkillViewModel()
            //    {
            //        Id = s.Id,
            //        Description = s.Description,
            //    })
            //    .ToList();

            //return skillsViewModels;
        }
    }
}