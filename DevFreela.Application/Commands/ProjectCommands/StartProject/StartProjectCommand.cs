using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.StartProject
{
    public class StartProjectCommand : IRequest<bool>
    {
        public StartProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}