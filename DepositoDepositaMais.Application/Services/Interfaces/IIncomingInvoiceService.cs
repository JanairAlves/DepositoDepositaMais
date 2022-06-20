using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IIncomingInvoiceService
    {
        List<IncomingInvoiceViewModel> GetAll(string query);
        IncomingInvoiceDetailsViewModel GetById(int id);
        int CreateNewIncomingInvoice(NewIncomingInvoiceInputModel inputModel);
        void UpdateIncomingInvoice(UpdateIncomingInvoiceInputModel inputModel);
        void ActivateIncomingInvoice(int id);
        void DeleteIncomingInvoice(int id);
    }
}
