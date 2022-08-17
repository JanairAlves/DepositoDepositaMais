using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public CategoryDetailsViewModel(int categoryId, string categoryName, string description, CategoryStatusEnum status, DateTime createdAt)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
        }

        public int CategoryId { get; }
        public string CategoryName { get; private set; }
        public string Description { get; private set; }
        public CategoryStatusEnum Status { get; }
        public DateTime CreatedAt { get; }

    }
}
