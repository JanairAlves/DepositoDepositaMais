using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string fullName, string email, DateTime birthDate, List<UserSkill> skill, UserStatusEnum status, DateTime createdAt, string depositName)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skill = skill;
            Status = status;
            CreatedAt = createdAt;
            DepositName = depositName;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<UserSkill> Skill { get; private set; }
        public UserStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public string DepositName { get; private set; }
    }
}
