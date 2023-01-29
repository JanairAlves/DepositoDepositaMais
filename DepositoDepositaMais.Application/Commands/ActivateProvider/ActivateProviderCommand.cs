using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateProvider
{
    public class ActivateProviderCommand : IRequest<Unit>
    {
        public ActivateProviderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
