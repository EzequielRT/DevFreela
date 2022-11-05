using Dapper;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.ProjectCommands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, bool>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public StartProjectCommandHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<bool> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

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
                               Id = request.Id,
                               Status = project.Status,
                               StartedAt = project.StartedAt
                           });

                return result > 0;
            }
        }
    }
}