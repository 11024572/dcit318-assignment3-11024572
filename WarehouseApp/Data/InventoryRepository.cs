using System;
using System.Collections.Generic;
using WarehouseApp.Interfaces;
using WarehouseApp.Exceptions;

namespace WarehouseApp.Data
{
    public class InventoryRepository<T> where T : IInventoryItem
    {
        private readonly Dictionary<int, T> _items = new();

        public void AddItem(T item)
        {
            if (_items.ContainsKey(item.Id))
                throw new DuplicateItemException($"Item with ID {item.Id} already exists.");
            _items[item.Id] = item;
        }

        public T GetItemById(int id)
        {
            if (!_items.TryGetValue(id, out var item))
                throw new ItemNotFoundException($"Item with ID {id} not found.");
            return item;
        }

        public void RemoveItem(int id)
        {
            if (!_items.Remove(id))
                throw new ItemNotFoundException($"Item with ID {id} not found.");
        }

        public List<T> GetAllItems() => new(_items.Values);

        public void UpdateQuantity(int id, int newQuantity)
        {
            if (newQuantity < 0)
                throw new InvalidQuantityException("Quantity cannot be negative.");

            var item = GetItemById(id);
            item.Quantity = newQuantity;
        }
    }
}
