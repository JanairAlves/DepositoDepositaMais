using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class StorageService : IStorageService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public StorageService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewStorage(NewStorageInputModel inputModel)
        {
            var storage = new Storage(
                inputModel.IdProduct,
                inputModel.Quantity,
                inputModel.MinimumQuantity,
                inputModel.MaximumQuantity,
                inputModel.Street
                );
            _dbContext.Storagehouse.Add(storage);

            return storage.Id;
        }

        public void UpdateStorage(UpdateStorageViewModel inputModel)
        {
            var storage = _dbContext.Storagehouse.FirstOrDefault(s => s.Id == inputModel.Id);
            storage.Update(
                inputModel.Quantity,
                inputModel.MinimumQuantity,
                inputModel.MaximumQuantity,
                inputModel.Street
                );            
        }

        public List<StorageViewModel> GetAll(string query)
        {
            var storage = _dbContext.Storagehouse;
            var storageViewModel = storage
                .Select(s => new StorageViewModel(
                    s.Id,
                    s.IdProduct,
                    s.Quantity,
                    s.Street)
                ).ToList();

            return storageViewModel;
        }

        public StorageDetailsViewModel GetById(int id)
        {
            var storage = _dbContext.Storagehouse.SingleOrDefault(s => s.Id == id);
            var storageViewModel = new StorageDetailsViewModel(
                storage.Id,
                storage.IdProduct,
                storage.Quantity,
                storage.MinimumQuantity,
                storage.MaximumQuantity,
                storage.Street);

            return storageViewModel;
        }
    }
}
