using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailsViewModel> GetById(int id);
        Task<int> Create(CreateUserInputModel inputModel);
    }
}