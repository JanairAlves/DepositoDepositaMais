using DepositoDepositaMais.Core.Enums;
using MediatR;
using System;

namespace DepositoDepositaMais.Application.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; private set; }
        public string Description { get; private set; }
        public CategoryStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
