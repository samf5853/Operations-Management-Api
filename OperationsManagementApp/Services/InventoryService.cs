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
}