using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            IEnumerable<Skill> skills = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();

                var sql = "SELECT Id, Description, CreatedAt FROM Skill";

                skills = await sqlConnection.QueryAsync<Skill>(sql);
            }

            return skills.ToList();
        }
    }
}