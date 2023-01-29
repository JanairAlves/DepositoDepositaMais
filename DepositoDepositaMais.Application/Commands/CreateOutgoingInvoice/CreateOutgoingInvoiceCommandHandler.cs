using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateOutgoingInvoice
{
    public class CreateOutgoingInvoiceCommandHandler : IRequestHandler<CreateOutgoingInvoiceCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateOutgoingInvoiceCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateOutgoingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = new OutgoingInvoice(
                request.DepositId,
                request.StorageLocationId,
                request.ProductId,
                request.Quantity,
                request.Value,
                request.Description,
                request.SubmittedIn
                );

            await _dbContext.OutgoingInvoices.AddAsync(outgoingInvoice);
            await _dbContext.SaveChangesAsync();

            return outgoingInvoice.Id;
        }
    }
}
