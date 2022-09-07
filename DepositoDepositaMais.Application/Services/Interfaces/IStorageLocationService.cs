using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IStorageLocationService
    {
        List<StorageLocationViewModel> GetAll(string query);
        StorageLocationDetailsViewModel GetById(int id);
        int CreateNewStorageLocation(NewStorageLocationInputModel inputModel);
        void UpdateStorageLocation(UpdateStorageLocationInputModel inputModel);
        void ActivateStorageLocation(int id);
        void DeleteStorageLocation(int id);
        
    }
}
