using DevFreela.Application.Queries.ProjectQueries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries.ProjectQueries
{
    public class GetAllProjectsQueryHandlerTests
    {
        private GetAllProjectsQueryHandler _getAllProjectsQueryHandler;
        private readonly Mock<IProjectRepository> _mockProjectRepository;

        public GetAllProjectsQueryHandlerTests()
        {
            _mockProjectRepository = new Mock<IProjectRepository>();
            _getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(_mockProjectRepository.Object);
        }

        [Fact]
        public async void ThreeProjectExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arranje
            var projects = new List<Project>()
            {
                new Project("Teste 1", "Descrição teste 1", 1, 2, 10000),
                new Project("Teste 2", "Descrição teste 2", 1, 2, 20000),
                new Project("Teste 3", "Descrição teste 3", 1, 2, 30000)
            };

            _mockProjectRepository.Setup(pr => pr.GetAllProjectsAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery();

            // Act
            var projectViewModelList = await _getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            _mockProjectRepository.Verify(pr => pr.GetAllProjectsAsync().Result, Times.Once);
        }
    }
}