﻿using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class IncomingOrderViewModel
    {
        public IncomingOrderViewModel(int id, int depositId, int quantity, decimal value, IncomingOrderStatusEnum status, DateTime createdAt)
        {
            Id = id;
            DepositId = depositId;
            Quantity = quantity;
            Value = value;
            Status = status;
            CreatedAt = createdAt;
        }

        public int Id { get; }
        public int DepositId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public IncomingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
