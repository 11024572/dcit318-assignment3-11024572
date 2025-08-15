using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using InventorySystem.Interfaces;

namespace InventorySystem.Services
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private readonly List<T> _log = new();
        private readonly string _filePath;

        public InventoryLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T item)
        {
            _log.Add(item);
        }

        public List<T> GetAll()
        {
            return new List<T>(_log);
        }

        public void SaveToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("No saved file found.");
                    return;
                }

                string json = File.ReadAllText(_filePath);
                var items = JsonSerializer.Deserialize<List<T>>(json);

                if (items != null)
                {
                    _log.Clear();
                    _log.AddRange(items);
                    Console.WriteLine("Data loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }
    }
}
