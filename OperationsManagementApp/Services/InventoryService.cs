using OperationsManagementApp.DTOs;
using OperationsManagementApp.Models;
using OperationsManagementApp.Repositories;

namespace OperationsManagementApp.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _repository;
    
    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<InventoryDto>> GetInventoryAsync()
    {
        var items = await _repository.GetAllAsync();

        return items.Select(item => new InventoryDto
        {
            Id = item.Id,
            Name = item.Name,
            SKU = item.SKU,
            Quantity = item.Quantity
        }).ToList();
    }

    public async Task<InventoryItem> CreateItemAsync(InventoryItem item)
    {
        return await _repository.CreateAsync(item);
    }

    public async Task<InventoryItem> UpdateItemAsync(int id, InventoryItem updatedItem)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return null;
        
        // Business logic to update the item
        if (updatedItem.Quantity < 0)
        {
            throw new Exception("Quantity cannot be negative");
        }
        
        existing.Name = updatedItem.Name;
        existing.SKU = updatedItem.SKU;
        existing.Quantity = updatedItem.Quantity;
        existing.Cost = updatedItem.Cost;
        
        return await _repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}