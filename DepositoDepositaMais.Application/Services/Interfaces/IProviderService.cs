using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IProviderService
    {
        List<ProviderViewModel> GetAll(string query);
        ProviderDetailsViewModel GetById(int id);
        int CreateNewProvider(NewProviderInputModel inputModel);
        void UpdateProvider(UpdateProviderInputModel inputModel);
        void ActivateProvider(int id);
        void DeleteProvider(int id);
    }
}
