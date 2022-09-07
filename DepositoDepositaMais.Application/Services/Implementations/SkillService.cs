using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;


namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public SkillService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _dbContext.Skills;

            var skillsViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description)
                ).ToList();

            return skillsViewModel;
        }
    }
}
