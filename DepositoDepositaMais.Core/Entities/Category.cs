using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
            CreatedAt = DateTime.Now;
            Status = CategoryStatusEnum.Active;
        }

        public string CategoryName { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public CategoryStatusEnum Status { get; private set; }

        public void Update(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
        }

        public void Activate()
        {
            if (Status == CategoryStatusEnum.Inactive)
                Status = CategoryStatusEnum.Active;
        }

        public void Inactivate()
        {
            if(Status == CategoryStatusEnum.Active)
                Status = CategoryStatusEnum.Inactive;
        }
    }
}
