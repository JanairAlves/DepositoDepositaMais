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
    public class StoragePlaceService : IStoragePlaceService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public StoragePlaceService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewStoragePlace(NewStoragePlaceInputModel inputModel)
        {
            var storagePlace = new StoragePlace(
                inputModel.IdProduct,
                inputModel.Quantity,
                inputModel.MinimumQuantity,
                inputModel.MaximumQuantity,
                inputModel.Street
                );
            _dbContext.StoragePlace.Add(storagePlace);

            return storagePlace.Id;
        }

        public void UpdateStoragePlace(UpdateStoragePlaceViewModel inputModel)
        {
            var storagePlace = _dbContext.StoragePlace.FirstOrDefault(s => s.Id == inputModel.Id);
            storagePlace.Update(
                inputModel.Quantity,
                inputModel.MinimumQuantity,
                inputModel.MaximumQuantity,
                inputModel.Street
                );            
        }

        public List<StoragePlaceViewModel> GetAll(string query)
        {
            var storagePlace = _dbContext.StoragePlace;
            var storagePlaceViewModel = storagePlace
                .Select(s => new StoragePlaceViewModel(
                    s.Id,
                    s.IdProduct,
                    s.Quantity,
                    s.Street)
                ).ToList();

            return storagePlaceViewModel;
        }

        public StoragePlaceDetailsViewModel GetById(int id)
        {
            var storagePlace = _dbContext.StoragePlace.SingleOrDefault(s => s.Id == id);
            var storagePlaceViewModel = new StoragePlaceDetailsViewModel(
                storagePlace.Id,
                storagePlace.IdProduct,
                storagePlace.Quantity,
                storagePlace.MinimumQuantity,
                storagePlace.MaximumQuantity,
                storagePlace.Street);

            return storagePlaceViewModel;
        }
    }
}
