using DepositoDepositaMais.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<UserSkill> Skill { get; private set; }
    }
}
