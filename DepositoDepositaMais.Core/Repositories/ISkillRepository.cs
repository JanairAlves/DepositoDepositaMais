using DepositoDepositaMais.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSkillByIdAsync(int id);
    }
}
