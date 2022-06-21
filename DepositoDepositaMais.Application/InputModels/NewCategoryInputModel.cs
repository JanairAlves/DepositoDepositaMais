using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class NewCategoryInputModel
    {
        public NewCategoryInputModel(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
            Status = 0;
            CreatedAt = DateTime.Now;
        }

        public string CategoryName { get; private set; }
        public string Description { get; private set; }
        public CategoryStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
