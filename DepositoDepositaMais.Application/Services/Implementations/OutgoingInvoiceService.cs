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
                inputModel.DepositId,
                inputModel.StorageLocationId,
                inputModel.ProductId,
                inputModel.Quantity,
                inputModel.Value,
                inputModel.Description,
                inputModel.SubmittedIn
                );

            _dbContext.OutgoingInvoices.Add(outgoingInvoice);

            _dbContext.SaveChanges();

            return outgoingInvoice.Id;
        }

        public void UpdateOutgoingInvoice(UpdateOutgoingInvoiceInputModel inputModel)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices.SingleOrDefault(oi => oi.Id == inputModel.Id);

            outgoingInvoice.Update(
                inputModel.StorageLocationId,
                inputModel.ProductId,
                inputModel.Quantity,
                inputModel.Value,
                inputModel.Description,
                inputModel.SubmittedIn
                );

            _dbContext.SaveChanges();
        }

        public List<OutgoingInvoiceViewModel> GetAll(string query)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices;

            var outgoingInvoiceViewModel = outgoingInvoice
                .Select(oi => new OutgoingInvoiceViewModel(
                    oi.Id,
                oi.DepositId,
                oi.StorageLocationId,
                oi.ProductId,
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
                outgoingInvoice.DepositId,
                outgoingInvoice.StorageLocationId,
                outgoingInvoice.ProductId,
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

            _dbContext.SaveChanges();
        }

        public void DeleteOutgoingInvoice(int id)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices.SingleOrDefault(oi => oi.Id == id);

            outgoingInvoice.Inactivate();

            _dbContext.SaveChanges();
        }
    }
}
