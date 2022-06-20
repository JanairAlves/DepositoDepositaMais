using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll(string query);
        UserDetailsViewModel GetById(int id);
        int CreateNewUser(NewUserInputModel inputModel);
        void UpdateUser(UpdateUserInputModel inputModel);
        void ActivateUser(int id);
        void DeleteUser(int id);
    }
}
