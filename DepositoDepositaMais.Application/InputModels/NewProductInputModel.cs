﻿using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class NewProductInputModel
    {
        public string ProductCode { get; private set; }
        public int ProviderId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public string PackagingType { get; private set; }
        public string QuantityPackaging { get; private set; }
        public ProductStatusEnum Status { get; private set; }
        public DateTime CreateAt { get; private set; }
    }
}
