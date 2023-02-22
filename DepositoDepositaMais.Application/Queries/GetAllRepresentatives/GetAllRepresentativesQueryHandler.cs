using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllRepresentatives
{
    public class GetAllRepresentativesQueryHandler : IRequestHandler<GetAllRepresentativesQuery, List<RepresentativeViewModel>>
    {
        private readonly IRepresentativeRepository _representativeRepository;
        public GetAllRepresentativesQueryHandler(IRepresentativeRepository representativeRepository)
        {
            _representativeRepository = representativeRepository;
        }

        public async Task<List<RepresentativeViewModel>> Handle(GetAllRepresentativesQuery request, CancellationToken cancellationToken)
        {
            var representatives = await _representativeRepository.GetAllRepresentativesAsync();

            var representativesViewModel =  representatives
                .Select(r => new RepresentativeViewModel(
                    r.ProviderId,
                    r.RepresentativeName,
                    r.PhoneNumber,
                    r.Email,
                    r.Description)
                ).ToList();

            return representativesViewModel;
        }
    }
}
