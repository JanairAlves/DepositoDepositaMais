using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, List<UserSkill> skill)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;

            Skill = skill;
            Status = UserStatusEnum.Active;
            CreatedAt = DateTime.Now;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<UserSkill> Skill { get; private set; }
        public UserStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
        public void Update(string fullName, string email, DateTime birthDate, List<UserSkill> skill)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skill = skill;
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
