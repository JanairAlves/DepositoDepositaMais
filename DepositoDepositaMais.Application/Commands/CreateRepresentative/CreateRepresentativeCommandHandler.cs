using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateRepresentative
{
    public class CreateRepresentativeCommandHandler : IRequestHandler<CreateRepresentativeCommand, int>
    {
        private readonly IRepresentativeRepository _representativeRepository;
        public CreateRepresentativeCommandHandler(IRepresentativeRepository representativeRepository)
        {
            _representativeRepository = representativeRepository;
        }

        public async Task<int> Handle(CreateRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var representative = new Representative(
                request.ProviderId,
                request.RepresentativeName,
                request.Birthday,
                request.CPF,
                request.PhoneNumber,
                request.Email,
                request.Description
                );

            await _representativeRepository.CreateRepresentative(representative);

            return representative.Id;
        }
    }
}
