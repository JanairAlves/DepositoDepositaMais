using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllRepresentatives
{
    public class GetAllRepresentativesQueryHandler : IRequestHandler<GetAllRepresentativesQuery, List<RepresentativeViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllRepresentativesQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RepresentativeViewModel>> Handle(GetAllRepresentativesQuery request, CancellationToken cancellationToken)
        {
            var representative = _dbContext.Representatives;

            var representativeViewModel = await representative
                .Select(r => new RepresentativeViewModel(
                    r.ProviderId,
                    r.RepresentativeName,
                    r.PhoneNumber,
                    r.Email,
                    r.Description)
                ).ToListAsync();

            return representativeViewModel;
        }
    }
}
