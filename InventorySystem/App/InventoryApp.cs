using System;
using InventorySystem.Models;
using InventorySystem.Services;

namespace InventorySystem.App
{
    public class InventoryApp
    {
        private readonly InventoryLogger<InventoryItem> _logger;

        public InventoryApp(string filePath)
        {
            _logger = new InventoryLogger<InventoryItem>(filePath);
        }

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Laptop", 10, DateTime.Now));
            _logger.Add(new InventoryItem(2, "Phone", 25, DateTime.Now));
            _logger.Add(new InventoryItem(3, "Tablet", 15, DateTime.Now));
            _logger.Add(new InventoryItem(4, "Monitor", 8, DateTime.Now));
            _logger.Add(new InventoryItem(5, "Keyboard", 20, DateTime.Now));
        }

        public void SaveData()
        {
            _logger.SaveToFile();
        }

        public void LoadData()
        {
            _logger.LoadFromFile();
        }

        public void PrintAllItems()
        {
            var items = _logger.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded}");
            }
        }
    }
}
