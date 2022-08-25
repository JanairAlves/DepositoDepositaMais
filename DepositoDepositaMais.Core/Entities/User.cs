using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;

            UserSkills = new List<UserSkill>();
            Status = UserStatusEnum.Active;
            CreatedAt = DateTime.Now;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public UserStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public int DepositId { get; private set; }
        public Deposit Deposit { get; private set; }
        public List<UserSkill> UserSkills { get; private set; }

        public void Update(string fullName, string email, DateTime birthDate, List<UserSkill> skills)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            UserSkills = skills;
        }

        public void Activate()
        {
            if(Status == UserStatusEnum.Inactive)
                Status = UserStatusEnum.Active;
        }

        public void Inactivate()
        {
            if(Status == UserStatusEnum.Active)
                Status = UserStatusEnum.Inactive;
        }
    }
}
