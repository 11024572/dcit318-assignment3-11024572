using System;
using InventorySystem.Interfaces;

namespace InventorySystem.Models
{
    // Immutable record for inventory item
    public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity;
}
