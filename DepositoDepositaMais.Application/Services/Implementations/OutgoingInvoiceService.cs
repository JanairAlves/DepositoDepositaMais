using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class OutgoingInvoiceService : IOutgoingInvoiceService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public OutgoingInvoiceService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewOutgoingInvoice(NewOutgoingInvoiceInputModel inputModel)
        {
            var outgoingInvoice = new OutgoingInvoice(
                inputModel.IdDeposito,
                inputModel.IdStorage,
                inputModel.IdProduct,
                inputModel.Quantity,
                inputModel.Value,
                inputModel.Description,
                inputModel.SubmittedIn
                );
            _dbContext.OutgoingInvoices.Add(outgoingInvoice);

            return outgoingInvoice.Id;
        }

        public void UpdateOutgoingInvoice(UpdateOutgoingInvoiceInputModel inputModel)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices.SingleOrDefault(oi => oi.Id == inputModel.Id);
            outgoingInvoice.Update(
                inputModel.IdStorage,
                inputModel.IdProduct,
                inputModel.Quantity,
                inputModel.Value,
                inputModel.Description,
                inputModel.SubmittedIn
                );
        }

        public List<OutgoingInvoiceViewModel> GetAll(string query)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices;
            var outgoingInvoiceViewModel = outgoingInvoice
                .Select(oi => new OutgoingInvoiceViewModel(
                    oi.Id,
                oi.IdDeposito,
                oi.IdStorage,
                oi.IdProduct,
                oi.Quantity,
                oi.Value)
                ).ToList();

            return outgoingInvoiceViewModel;
        }

        public OutgoingInvoiceDetailsViewModel GetById(int id)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices.SingleOrDefault(oi => oi.Id == id);
            var outgoingInvoiceDetailsViewModel = new OutgoingInvoiceDetailsViewModel(
                outgoingInvoice.Id,
                outgoingInvoice.IdDeposito,
                outgoingInvoice.IdStorage,
                outgoingInvoice.IdProduct,
                outgoingInvoice.Quantity,
                outgoingInvoice.Value,
                outgoingInvoice.Description,
                outgoingInvoice.Status,
                outgoingInvoice.CreatedAt,
                outgoingInvoice.SubmittedIn
                );

            return outgoingInvoiceDetailsViewModel;
        }

        public void ActivateOutgoingInvoice(int id)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices.SingleOrDefault(oi => oi.Id == id);
            outgoingInvoice.Activate();
        }

        public void DeleteOutgoingInvoice(int id)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices.SingleOrDefault(oi => oi.Id == id);
            outgoingInvoice.Inactivate();
        }
    }
}
