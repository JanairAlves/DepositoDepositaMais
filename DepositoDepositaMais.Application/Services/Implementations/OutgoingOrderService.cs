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
    public class OutgoingOrderService : IOutgoingOrderService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public OutgoingOrderService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewOutgoingOrder(NewOutgoingOrderInputModel inputModel)
        {
            var outgoingOrder = new OutgoingOrder(
                inputModel.IdDeposit,
                inputModel.IdStoragePlace,
                inputModel.IdProduct,
                inputModel.Quantity,
                inputModel.Value,
                inputModel.Description,
                inputModel.SendIn
                );
            _dbContext.OutgoingOrders.Add(outgoingOrder);

            return outgoingOrder.Id;
        }

        public void UpdateOutgoingOrder(UpdateOutgoingOrderInputModel inputModel)
        {
            var outgoingOrder = _dbContext.OutgoingOrders.SingleOrDefault(oo => oo.Id == inputModel.Id);
            outgoingOrder.Update(
                inputModel.IdStoragePlace,
                inputModel.IdProduct,
                inputModel.Quantity,
                inputModel.Value,
                inputModel.Description,
                inputModel.SendIn
                );           
        }

        public List<OutgoingOrderViewModel> GetAll(string query)
        {
            var outgoingOrder = _dbContext.OutgoingOrders;
            var outgoingOrderViewModel = outgoingOrder
                .Select(oo => new OutgoingOrderViewModel(
                    oo.Id,
                    oo.IdDeposit,
                    oo.IdStoragePlace,
                    oo.IdProduct,
                    oo.Quantity,
                    oo.Value)
                ).ToList();

            return outgoingOrderViewModel;
        }

        public OutgoingOrderDetailsViewModel GetById(int id)
        {
            var outgoingOrder = _dbContext.OutgoingOrders.SingleOrDefault(oo => oo.Id == id);
            var outgoingOrderDetailsViewModel = new OutgoingOrderDetailsViewModel(
                outgoingOrder.Id,
                outgoingOrder.IdDeposit,
                outgoingOrder.IdStoragePlace,
                outgoingOrder.IdProduct,
                outgoingOrder.Quantity,
                outgoingOrder.Value,
                outgoingOrder.Description,
                outgoingOrder.Status,
                outgoingOrder.CreatedAt,
                outgoingOrder.SendIn
                );

            return outgoingOrderDetailsViewModel;
        }

        public void ActivateOutgoingOrder(int id)
        {
            var outgoingOrder = _dbContext.OutgoingOrders.SingleOrDefault(oo => oo.Id == id);
            outgoingOrder.Activate();
        }

        public void DeleteOutgoingOrder(int id)
        {
            var outgoingOrder = _dbContext.OutgoingOrders.SingleOrDefault(oo => oo.Id == id);
            outgoingOrder.Inactivate();
        }
    }
}
