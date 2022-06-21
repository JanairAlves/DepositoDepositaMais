using DepositoDepositaMais.Core.Entities;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateUserInputModel
    {
        public UpdateUserInputModel(int id, string fullName, string email, DateTime birthDate, List<UserSkill> skill)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skill = skill;
        }

        public int Id { get; set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<UserSkill> Skill { get; private set; }
    }
}
