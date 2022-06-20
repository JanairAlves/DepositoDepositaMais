using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IDepositService
    {
        List<DepositViewModel> GetAll(string query);
        DepositDetailsViewModel GetById(int id);
        int CreateNewDeposit(NewDepositInputModel inputModel);
        void UpdateDeposit(UpdateDepositInputModel inputModel);
        void ActivateDeposit(int id);
        void DeleteDeposit(int id);

    }
}
