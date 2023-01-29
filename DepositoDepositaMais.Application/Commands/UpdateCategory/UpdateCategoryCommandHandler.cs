using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateCategoryCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == request.Id);

            category.Update(request.CategoryName, request.Description);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
