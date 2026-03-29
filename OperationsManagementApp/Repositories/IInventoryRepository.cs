using OperationsManagementApp.Models;

namespace OperationsManagementApp.Repositories;

public interface IInventoryRepository
{
    Task<List<InventoryItem>> GetAllAsync();
    
    Task<InventoryItem> CreateAsync(InventoryItem item);
    
    Task<InventoryItem?> GetByIdAsync(int id);
    
    Task<InventoryItem> UpdateAsync(InventoryItem item);
    
    Task<bool> DeleteAsync(int id);

    Task<List<InventoryItem>> GetByIdsAsync(List<int> ids);
}