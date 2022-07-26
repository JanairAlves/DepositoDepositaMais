using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IStoragePlaceService
    {
        List<StoragePlaceViewModel> GetAll(string query);
        StoragePlaceDetailsViewModel GetById(int id);
        int CreateNewStoragePlace(NewStoragePlaceInputModel inputModel);
        void UpdateStoragePlace(UpdateStoragePlaceViewModel inputModel);
    }
}
