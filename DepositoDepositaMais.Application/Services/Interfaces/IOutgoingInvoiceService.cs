using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IOutgoingInvoiceService
    {
        List<OutgoingInvoiceViewModel> GetAll(string query);
        OutgoingInvoiceDetailsViewModel GetById(int id);
        int CreateNewOutgoingInvoice(NewOutgoingInvoiceInputModel inputModel);
        void UpdateOutgoingInvoice(UpdateOutgoingInvoiceInputModel inputModel);
        void ActivateOutgoingInvoice(int id);
        void DeleteOutgoingInvoice(int id);
    }
}
