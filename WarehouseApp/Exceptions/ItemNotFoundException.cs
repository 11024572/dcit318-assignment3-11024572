using System;

namespace WarehouseApp.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message) { }
    }
}
