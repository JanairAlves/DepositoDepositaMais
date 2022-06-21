using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IRepresentativeService
    {
        List<RepresentativeViewModel> GetAll(string query);
        RepresentativeDetailsViewModel GetById(int id);
        int CreateNewRepresentative(NewRepresentativeInputModel inputModel);
        void UpdateRepresentative(UpdateRepresentativeInputModel inputModel);
        void ActivateRepresentative(int id);
        void DeleteRepresentative(int id);
    }
}
