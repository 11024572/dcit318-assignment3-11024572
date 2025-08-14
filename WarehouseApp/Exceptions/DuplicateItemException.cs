using System;

namespace WarehouseApp.Exceptions
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }
}
