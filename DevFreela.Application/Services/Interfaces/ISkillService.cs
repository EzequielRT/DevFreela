using DevFreela.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface ISkillService
    {
        Task<List<SkillViewModel>> GetAll();
    }
}