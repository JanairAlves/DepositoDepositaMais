using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public SkillRepository(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Skill>> GetAllSkillsAsync()
        {
            return await _dbContext.Skills.ToListAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await _dbContext.Skills.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
