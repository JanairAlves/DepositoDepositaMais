using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IStorageService
    {
        List<StorageViewModel> GetAll(string query);
        StorageDetailsViewModel GetById(int id);
        int CreateNewStorage(NewStorageInputModel inputModel);
        void UpdateStorage(UpdateStorageViewModel inputModel);
        void ActivateRepresentative(int id);
        void DeleteRepresentative(int id);
    }
}
