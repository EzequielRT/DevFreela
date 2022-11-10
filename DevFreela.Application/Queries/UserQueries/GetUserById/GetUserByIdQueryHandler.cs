using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);

            if (user == null)
                return null;

            var userDetailsViewModel = new UserDetailsViewModel()
            {
                FullName = user.FullName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                CreatedAt = user.CreatedAt,
                Active = user.Active
            };

            return userDetailsViewModel;
        }
    }
}