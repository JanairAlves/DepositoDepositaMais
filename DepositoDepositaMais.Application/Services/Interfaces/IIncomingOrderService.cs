using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IIncomingOrderService
    {
        List<IncomingOrderViewModel> GetAll(string query);
        IncomingOrderDetailsViewModel GetById(int id);
        int CreateNewIncomingOrder(NewIncomingOrderInputModel inputModel);
        void UpdateIncomingOrder(UpdateIncomingOrderInputModel inputModel);
        void ActivateIncomingOrder(int id);
        void DeleteIncomingOrder(int id);
    }
}
