using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class IncomingInvoiceService : IIncomingInvoiceService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public IncomingInvoiceService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewIncomingInvoice(NewIncomingInvoiceInputModel inputModel)
        {
            var incomingInvoice = new IncomingInvoice(
                inputModel.CompanyName,
                inputModel.CompanyAddress,
                inputModel.CNPJCompany,
                inputModel.CPFCompany,
                inputModel.CompanyStateRegistration,

                inputModel.CarrierName,
                inputModel.CodeResponsibility,
                inputModel.CarPlate,
                inputModel.CNPJCarrier,
                inputModel.CPFCarrier,
                inputModel.CarrierAdress,
                inputModel.CarrierStateRegistration,

                inputModel.TypeOfVolume,
                inputModel.WeightOfTheCargo,

                inputModel.Description ,
                inputModel.ReceivedIn
                );
            _dbContext.IncomingInvoices.Add(incomingInvoice);

            _dbContext.SaveChanges();

            return incomingInvoice.Id;
        }

        public void UpdateIncomingInvoice(UpdateIncomingInvoiceInputModel inputModel)
        {
            var incomingInvoice = _dbContext.IncomingInvoices.SingleOrDefault(ii => ii.Id == inputModel.Id);
            incomingInvoice.Update(
                inputModel.CompanyName,
                inputModel.CompanyAddress,
                inputModel.CNPJCompany,
                inputModel.CPFCompany,
                inputModel.CompanyStateRegistration,

                inputModel.CarrierName,
                inputModel.CodeResponsibility,
                inputModel.CarPlate,
                inputModel.CNPJCarrier,
                inputModel.CPFCarrier,
                inputModel.CarrierAdress,
                inputModel.CarrierStateRegistration,
                
                inputModel.TypeOfVolume,
                inputModel.WeightOfTheCargo,
                
                inputModel.Status,
                inputModel.Description,
                inputModel.ReceivedIn
                );

            _dbContext.SaveChanges();
        }

        public List<IncomingInvoiceViewModel> GetAll(string query)
        {
            var incomingInvoice = _dbContext.IncomingInvoices;
            var incomingInvoiceViewModel = incomingInvoice
                .Select(ii => new IncomingInvoiceViewModel(
                    ii.Id, 
                    ii.CompanyName, 
                    ii.CNPJCompany, 
                    ii.CPFCompany, 
                    ii.CarrierName, 
                    ii.CarPlate, 
                    ii.CNPJCarrier, 
                    ii.CPFCarrier)
                ).ToList();

            return incomingInvoiceViewModel;
        }

        public IncomingInvoiceDetailsViewModel GetById(int id)
        {
            var incomingInvoice = _dbContext.IncomingInvoices.SingleOrDefault(ii => ii.Id == id);
            var incomingInvoiceDetailsViewModel = new IncomingInvoiceDetailsViewModel(
                incomingInvoice.Id,
                incomingInvoice.CompanyName,
                incomingInvoice.CompanyAddress,
                incomingInvoice.CNPJCompany,
                incomingInvoice.CPFCompany,
                incomingInvoice.CompanyStateRegistration,
                incomingInvoice.CarrierName,
                incomingInvoice.CodeResponsibility,
                incomingInvoice.CarPlate,
                incomingInvoice.CNPJCarrier,
                incomingInvoice.CPFCarrier,
                incomingInvoice.CarrierAdress,
                incomingInvoice.CarrierStateRegistration,

                incomingInvoice.TypeOfVolume,
                incomingInvoice.WeightOfTheCargo
                );

            return incomingInvoiceDetailsViewModel;
        }

        public void ActivateIncomingInvoice(int id)
        {
            var incomingInvoice = _dbContext.IncomingInvoices.SingleOrDefault(ii => ii.Id == id);
            incomingInvoice.Activate();

            _dbContext.SaveChanges();
        }

        public void DeleteIncomingInvoice(int id)
        {
            var incomingInvoice = _dbContext.IncomingInvoices.SingleOrDefault(ii => ii.Id == id);
            incomingInvoice.Inactivate();

            _dbContext.SaveChanges();
        }
    }
}
