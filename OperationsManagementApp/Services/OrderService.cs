using OperationsManagementApp.DTOs;
using OperationsManagementApp.Models;
using OperationsManagementApp.Repositories;

namespace OperationsManagementApp.Services;

public class OrderService : IOrderService
{
    private readonly IInventoryRepository _repository;
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IInventoryRepository repository, IOrderRepository orderRepository)
    {
        _repository = repository;
        _orderRepository = orderRepository;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderRequest request)
    {
        var ids = request.Items.Select(i => i.InventoryItemId).ToList();

        var inventoryItems = await _repository.GetByIdsAsync(ids);

        foreach (var requestItem in request.Items)
        {
            var inventoryItem = inventoryItems
                .FirstOrDefault(i => i.Id == requestItem.InventoryItemId);

            if (inventoryItem == null)
            {
                throw new Exception($"Item with ID {requestItem.InventoryItemId} not found");
            }

            if (requestItem.Quantity > inventoryItem.Quantity)
            {
                throw new Exception(
                    $"Not enough stock for {inventoryItem.Name}. Available: {inventoryItem.Quantity}"
                );
            }
            
            inventoryItem.Quantity -= requestItem.Quantity;
        }

        var order = new Order
        {
            CustomerName = request.CustomerName,
            Status = "Pending",
            OrderDate = DateTime.UtcNow,
            Items = []
        };

        foreach (var requestItem in request.Items)
        {
            order.Items.Add(new OrderItem
            {
                InventoryItemId = requestItem.InventoryItemId,
                Quantity = requestItem.Quantity,
                Price = 0 // Placeholder
            });
        }
        
        await _orderRepository.CreateOrderAsync(order);
        
        return order;
    }
}