using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands.ProjectCommands
{
    public class CreateProjectCommandHandlerTests
    {
        private CreateProjectCommandHandler _createProjectCommandHandler;
        private readonly Mock<IProjectRepository> _mockProjectRepository;

        public CreateProjectCommandHandlerTests()
        {
            _mockProjectRepository = new Mock<IProjectRepository>();
            _createProjectCommandHandler = new CreateProjectCommandHandler(_mockProjectRepository.Object);
        }

        [Fact]
        public async void InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arranje
            var createProjectCommand = new CreateProjectCommand()
            {
                Title = "Teste",
                Description = "Teste",
                TotalCost = 50000,
                IdClient = 1,
                IdFreelancer = 2
            };

            // Act
            var id = await _createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);
            _mockProjectRepository.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}