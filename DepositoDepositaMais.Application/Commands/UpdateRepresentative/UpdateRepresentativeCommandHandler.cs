using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateRepresentative
{
    public class UpdateRepresentativeCommandHandler : IRequestHandler<UpdateRepresentativeCommand, Unit>
    {
        private readonly IRepresentativeRepository _representativeRepository;
        public UpdateRepresentativeCommandHandler(IRepresentativeRepository representativeRepository)
        {
            _representativeRepository = representativeRepository;
        }

        public async Task<Unit> Handle(UpdateRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var representative = await _representativeRepository.GetRepresentativeByIdAsync(request.Id);

            representative.Update(
                request.ProviderId,
                request.RepresentativeName,
                request.Birthday,
                request.CPF,
                request.PhoneNumber,
                request.Email,
                request.Description
                );

            await _representativeRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
