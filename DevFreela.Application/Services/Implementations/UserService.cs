using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(user);

            return user.Id;
        }

        public async Task<UserDetailsViewModel> GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);

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