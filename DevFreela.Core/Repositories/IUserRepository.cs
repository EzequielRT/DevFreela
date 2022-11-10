using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(int id);
    }
}