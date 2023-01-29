using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllSkillsQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = _dbContext.Skills;

            var skillsViewModel = await skills
                .Select(s => new SkillViewModel(s.Id, s.Description)
                ).ToListAsync();

            return skillsViewModel;
        }
    }
}
