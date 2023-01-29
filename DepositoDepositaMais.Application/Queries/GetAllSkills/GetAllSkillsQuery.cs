using DepositoDepositaMais.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}
