using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OperationsManagementApp.Data;
using OperationsManagementApp.DTOs;
using OperationsManagementApp.Models;
using OperationsManagementApp.Repositories;
using OperationsManagementApp.Services;

namespace OperationsManagementApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;

    public InventoryController(IInventoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetInventory()
    {
        var items = await _service.GetInventoryAsync();
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInventoryItem([FromBody] CreateInventoryItemRequest request)
    {
        var item = new InventoryItem()
        {
            Name = request.Name,
            SKU = request.SKU,
            Quantity = request.Quantity,
            Cost = request.Cost
        };
        
        var created = await _service.CreateItemAsync(item);
        return Ok(created);
    }
}