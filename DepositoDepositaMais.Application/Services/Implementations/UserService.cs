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
    public class UserService : IUserService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UserService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewUser(NewUserInputModel inputModel)
        {
            var user = new User(
                inputModel.FullName,
                inputModel.Email,
                inputModel.BirthDate
                );

            return user.Id;
        }

        public void UpdateUser(UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == inputModel.Id);
            user.Update(
                inputModel.FullName,
                inputModel.Email,
                inputModel.BirthDate,
                inputModel.Skill
                );
        }

        public List<UserViewModel> GetAll(string query)
        {
            var user = _dbContext.Users;
            var userViewModel = user
                .Select(u => new UserViewModel(
                    u.FullName,
                    u.Email,
                    u.BirthDate,
                    u.Status)
                ).ToList();

            return userViewModel;
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            var userDetailsViewModel = new UserDetailsViewModel(
                user.FullName,
                user.Email,
                user.BirthDate,
                user.Skills,
                user.Status,
                user.CreatedAt
                );

            return userDetailsViewModel;
        }

        public void ActivateUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            user.Activate();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            user.Inactivate();
        }
    }
}
