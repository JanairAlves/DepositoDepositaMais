using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public CategoryDetailsViewModel(int idCategory, string categoryName, string description, CategoryStatusEnum status, DateTime createdAt)
        {
            IdCategory = idCategory;
            CategoryName = categoryName;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
        }

        public int IdCategory { get; }
        public string CategoryName { get; private set; }
        public string Description { get; private set; }
        public CategoryStatusEnum Status { get; }
        public DateTime CreatedAt { get; }

    }
}
