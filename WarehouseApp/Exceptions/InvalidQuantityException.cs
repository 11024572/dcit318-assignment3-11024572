using System;

namespace WarehouseApp.Exceptions
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string message) : base(message) { }
    }
}
