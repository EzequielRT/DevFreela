using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByEmailAndPassowordAsync(string email, string passowordHash);
        public Task AddAsync(User user);
    }
}