using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System.Collections.Generic;


namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IOutgoingOrderService
    {
        List<OutgoingOrderViewModel> GetAll(string query);
        OutgoingOrderDetailsViewModel GetById(int id);
        int CreateNewOutgoingOrder(NewOutgoingOrderInputModel inputModel);
        void UpdateOutgoingOrder(UpdateOutgoingOrderInputModel inputModel);
        void ActivateOutgoingOrder(int id);
        void DeleteOutgoingOrder(int id);
    }
}
