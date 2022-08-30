using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class StorageLocationService : IStorageLocationService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public StorageLocationService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewStorageLocation(NewStorageLocationInputModel inputModel)
        {
            var storageLocation = new StorageLocation(
                inputModel.ProductId,
                inputModel.Quantity,
                inputModel.MinimumQuantity,
                inputModel.MaximumQuantity,
                inputModel.Street
                );
            _dbContext.StorageLocation.Add(storageLocation);

            _dbContext.SaveChanges();

            return storageLocation.Id;
        }

        public void UpdateStorageLocation(UpdateStorageLocationViewModel inputModel)
        {
            var storageLocation = _dbContext.StorageLocation.FirstOrDefault(s => s.Id == inputModel.Id);
            storageLocation.Update(
                inputModel.Quantity,
                inputModel.MinimumQuantity,
                inputModel.MaximumQuantity,
                inputModel.Street
                );

            _dbContext.SaveChanges();
        }

        public List<StorageLocationViewModel> GetAll(string query)
        {
            var storageLocation = _dbContext.StorageLocation;
            var storageLocationViewModel = storageLocation
                .Select(s => new StorageLocationViewModel(
                    s.Id,
                    s.ProductId,
                    s.Quantity,
                    s.Street)
                ).ToList();

            return storageLocationViewModel;
        }

        public StorageLocationDetailsViewModel GetById(int id)
        {
            var storageLocation = _dbContext.StorageLocation.SingleOrDefault(s => s.Id == id);
            var storageLocationViewModel = new StorageLocationDetailsViewModel(
                storageLocation.Id,
                storageLocation.ProductId,
                storageLocation.Quantity,
                storageLocation.MinimumQuantity,
                storageLocation.MaximumQuantity,
                storageLocation.Street);

            return storageLocationViewModel;
        }
    }
}
