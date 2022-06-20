using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, UserStatusEnum status)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Status = status;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public UserStatusEnum Status { get; private set; }
    }
}
