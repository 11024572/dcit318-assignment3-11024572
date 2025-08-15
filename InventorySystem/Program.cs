using System;
using InventorySystem.App;

class Program
{
    static void Main()
    {
        string filePath = "inventory.json";

        // Start the app
        InventoryApp app = new InventoryApp(filePath);

        // Seed data
        app.SeedSampleData();

        // Save to file
        app.SaveData();

        // Simulate new session (by creating a fresh instance)
        Console.WriteLine("\n--- New Session ---");
        InventoryApp newApp = new InventoryApp(filePath);
        newApp.LoadData();
        newApp.PrintAllItems();
    }
}
