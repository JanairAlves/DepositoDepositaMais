using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetRepresentativeById
{
    public class GetRepresentativeByIdQueryHandler : IRequestHandler<GetRepresentativeByIdQuery, RepresentativeDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetRepresentativeByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RepresentativeDetailsViewModel> Handle(GetRepresentativeByIdQuery request, CancellationToken cancellationToken)
        {
            var representative = await _dbContext.Representatives
                .Include(r => r.Provider)
                .SingleOrDefaultAsync(r => r.Id == request.Id);

            var representativeDetailsViewModel = new RepresentativeDetailsViewModel(
                representative.Id,
                representative.ProviderId,
                representative.RepresentativeName,
                representative.Birthday,
                representative.CPF,
                representative.PhoneNumber,
                representative.Email,
                representative.Description,
                representative.Status,
                representative.CreatedAt,
                representative.Provider.ProviderName,
                representative.Provider.CNPJ
                );

            return representativeDetailsViewModel;
        }
    }
}
