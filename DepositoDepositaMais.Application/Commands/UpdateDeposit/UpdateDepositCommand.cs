using MediatR;

namespace DepositoDepositaMais.Application.Commands.UpdateDeposit
{
    public class UpdateDepositCommand : IRequest<Unit>
    {
        public int Id { get; }
        public string DepositName { get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
    }
}
