using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CommentCommands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateCommentCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            return await _projectRepository.AddCommentAsync(comment);
        }
    }
}