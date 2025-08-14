namespace WarehouseApp.Interfaces
{
    // Marker Interface for inventory items
    public interface IInventoryItem
    {
        int Id { get; }
        string Name { get; }
        int Quantity { get; set; }
    }
}
