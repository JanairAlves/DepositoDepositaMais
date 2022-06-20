using System;

namespace DepositoDepositaMais.Core.Exceptions
{
    public class ProductAlreadyActivatedException : Exception
    {
        public ProductAlreadyActivatedException() : base ("Product is already in activated status.")
        {
        }
    }
}
