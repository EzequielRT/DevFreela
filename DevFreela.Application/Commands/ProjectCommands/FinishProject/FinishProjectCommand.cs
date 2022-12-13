using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.FinishProject
{
    public class FinishProjectCommand : IRequest<bool>
    {
        public int Id { get; private set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }

        public void SetProjectId(int projectId) => Id = projectId;
    }
}