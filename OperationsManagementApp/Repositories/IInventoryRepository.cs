using OperationsManagementApp.Models;

namespace OperationsManagementApp.Repositories;

public interface IInventoryRepository
{
    Task<List<InventoryItem>> GetAllAsync();
    
    Task<InventoryItem> CreateAsync(InventoryItem item);
}