using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class DepositService : IDepositService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public DepositService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewDeposit(NewDepositInputModel inputModel)
        {
            var deposit = new Deposit(inputModel.DepositName, inputModel.Description, inputModel.CNPJ);
            _dbContext.Deposits.Add(deposit);

            return deposit.Id;
        }

        public void UpdateDeposit(UpdateDepositInputModel inputModel)
        {
            var deposit = _dbContext.Deposits.SingleOrDefault(d => d.Id == inputModel.Id);
            deposit.Update(inputModel.DepositName, inputModel.Description, inputModel.CNPJ);
        }

        public List<DepositViewModel> GetAll(string query)
        {
            var deposits = _dbContext.Deposits;
            var depositsViewModel = deposits
                .Select(d => new DepositViewModel(d.Id, d.DepositName))
                .ToList();

            return depositsViewModel;
        }

        public DepositDetailsViewModel GetById(int id)
        {
            var deposit = _dbContext.Deposits.SingleOrDefault(d => d.Id == id);
            var depositsDetailsViewModel = new DepositDetailsViewModel(
                deposit.Id,
                deposit.DepositName,
                deposit.Description,
                deposit.CNPJ,
                deposit.Status,
                deposit.CreatedAt
                );

            return depositsDetailsViewModel;
        }

        public void ActivateDeposit(int id)
        {
            var deposit = _dbContext.Deposits.SingleOrDefault(d => d.Id == id);
            deposit.Activate();
        }

        public void DeleteDeposit(int id)
        {
            var deposit = _dbContext.Deposits.SingleOrDefault(d => d.Id == id);
            deposit.Inactivate();
        }
    }
}
