using DepositoDepositaMais.Application.ViewModels;
using System.Collections.Generic;


namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillViewModel> GetAll();
    }
}
