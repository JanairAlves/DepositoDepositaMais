using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class IncomingOrderService : IIncomingOrderService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public IncomingOrderService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewIncomingOrder(NewIncomingOrderInputModel inputModel)
        {
            var incomingOrder = new IncomingOrder(
                inputModel.DepositId,
                inputModel.RepresentativeId,
                inputModel.Quantity,
                inputModel.Value,
                inputModel.Description,
                inputModel.Status,
                inputModel.ExpectedDeliveryIn
                );
            _dbContext.IncomingOrders.Add(incomingOrder);

            return incomingOrder.Id;
        }

        public void UpdateIncomingOrder(UpdateIncomingOrderInputModel inputModel)
        {
            var incomingOrder = _dbContext.IncomingOrders.SingleOrDefault(io => io.Id == inputModel.Id);
            incomingOrder.Update(
                inputModel.Quantity,
                inputModel.Value,
                inputModel.Description,
                inputModel.ExpectedDeliveryIn
                );
        }

        public List<IncomingOrderViewModel> GetAll(string query)
        {
            var incomingOrder = _dbContext.IncomingOrders;
            var incomingOrderViewModel = incomingOrder
                .Select(io => new IncomingOrderViewModel(
                    io.Id,
                    io.DepositId,
                    io.Quantity,
                    io.Value,
                    io.Status,
                    io.CreatedAt)
                ).ToList();

            return incomingOrderViewModel;            
        }

        public IncomingOrderDetailsViewModel GetById(int id)
        {
            var incomingOrder = _dbContext.IncomingOrders.SingleOrDefault(io => io.Id == id);
            var incomingOrderDetailsViewModel = new IncomingOrderDetailsViewModel(
                incomingOrder.Id,
                incomingOrder.DepositId,
                incomingOrder.RepresentativeId,
                incomingOrder.Quantity,
                incomingOrder.Value,
                incomingOrder.Description,
                incomingOrder.Status,
                incomingOrder.CreatedAt,
                incomingOrder.ExpectedDeliveryIn
                );

            return incomingOrderDetailsViewModel;
        }

        public void ActivateIncomingOrder(int id)
        {
            var incomingOrder = _dbContext.IncomingOrders.SingleOrDefault(io => io.Id == id);
            incomingOrder.Activate();
        }

        public void DeleteIncomingOrder(int id)
        {
            var incomingOrder = _dbContext.IncomingOrders.SingleOrDefault(io => io.Id == id);
            incomingOrder.Inactivate();
        }
    }
}
