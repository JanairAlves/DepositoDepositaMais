using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetRepresentativeById
{
    public class GetRepresentativeByIdQueryHandler : IRequestHandler<GetRepresentativeByIdQuery, RepresentativeDetailsViewModel>
    {
        private readonly IRepresentativeRepository _representativeRepository;
        public GetRepresentativeByIdQueryHandler(IRepresentativeRepository representativeRepository)
        {
            _representativeRepository = representativeRepository;
        }

        public async Task<RepresentativeDetailsViewModel> Handle(GetRepresentativeByIdQuery request, CancellationToken cancellationToken)
        {
            var representative = await _representativeRepository.GetRepresentativeByIdAsync(request.Id);

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
