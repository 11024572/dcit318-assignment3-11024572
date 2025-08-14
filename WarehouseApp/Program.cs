using System;
using WarehouseApp.App;
using WarehouseApp.Models;
using WarehouseApp.Exceptions;

class Program
{
    static void Main()
    {
        var manager = new WareHouseManager();
        manager.SeedData();

        Console.WriteLine("=== Grocery Items ===");
        manager.PrintAllItems(manager.Groceries);

        Console.WriteLine("=== Electronic Items ===");
        manager.PrintAllItems(manager.Electronics);

        // Try: Add duplicate item
        try
        {
            manager.Electronics.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 12));
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"Duplicate error: {ex.Message}");
        }

        // Try: Remove non-existent item
        manager.RemoveItemById(manager.Groceries, 999);

        // Try: Update with invalid quantity
        try
        {
            manager.Electronics.UpdateQuantity(2, -5);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Invalid quantity: {ex.Message}");
        }
    }
}
