using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetUserByIdQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == request.Id);

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