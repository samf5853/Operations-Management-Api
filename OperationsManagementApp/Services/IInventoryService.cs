using OperationsManagementApp.DTOs;
using OperationsManagementApp.Models;

namespace OperationsManagementApp.Services;

public interface IInventoryService
{
    Task<List<InventoryDto>> GetInventoryAsync();

    Task<InventoryItem> CreateItemAsync(InventoryItem item);
}